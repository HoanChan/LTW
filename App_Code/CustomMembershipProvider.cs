﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Web.Security;

public class CustomMembershipProvider : System.Web.Security.MembershipProvider
{
    MyContextDataContext db = new MyContextDataContext();
    public override string ApplicationName
    {
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {
        throw new NotImplementedException();
    }

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        var args = new ValidatePasswordEventArgs(username, password, true);
        OnValidatingPassword(args);

        if (args.Cancel)
        {
            status = MembershipCreateStatus.InvalidPassword;
            return null;
        }

        if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
        {
            status = MembershipCreateStatus.DuplicateEmail;
            return null;
        }

        var user = GetUser(username, true);

        if (user == null)
        {
            //var userObj = new NguoiDung { Username = username, Password = GetMd5Hash(password), Email = email };
            var userObj = new NguoiDung { Username = username, Password = password, Email = email };

            db.NguoiDungs.InsertOnSubmit(userObj);
            db.SubmitChanges();

            status = MembershipCreateStatus.Success;

            return GetUser(username, true);
        }
        status = MembershipCreateStatus.DuplicateUserName;

        return null;
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        throw new NotImplementedException();
    }

    public override bool EnablePasswordReset
    {
        get { throw new NotImplementedException(); }
    }

    public override bool EnablePasswordRetrieval
    {
        get { throw new NotImplementedException(); }
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotImplementedException();
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotImplementedException();
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        throw new NotImplementedException();
    }

    public override int GetNumberOfUsersOnline()
    {
        throw new NotImplementedException();
    }

    public override string GetPassword(string username, string answer)
    {
        throw new NotImplementedException();
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        var user = db.NguoiDungs.FirstOrDefault(m=>m.Username == username);
        if (user != null)
        {
            var memUser = new MembershipUser("CustomMembershipProvider", username, user.Username + user.Password, user.Email,
                                                        string.Empty, string.Empty,
                                                        true, false, DateTime.MinValue,
                                                        user.LastLoginTime.Value,
                                                        DateTime.MinValue,
                                                        DateTime.Now, DateTime.Now);
            return memUser;
        }
        return null;
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        throw new NotImplementedException();
    }

    public override string GetUserNameByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public override int MaxInvalidPasswordAttempts
    {
        get { throw new NotImplementedException(); }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
        get { throw new NotImplementedException(); }
    }

    public override int MinRequiredPasswordLength
    {
        get { return 6; }
    }

    public override int PasswordAttemptWindow
    {
        get { throw new NotImplementedException(); }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
        get { throw new NotImplementedException(); }
    }

    public override string PasswordStrengthRegularExpression
    {
        get { throw new NotImplementedException(); }
    }

    public override bool RequiresQuestionAndAnswer
    {
        get { throw new NotImplementedException(); }
    }

    public override bool RequiresUniqueEmail
    {
        get { return false; }
    }

    public override string ResetPassword(string username, string answer)
    {
        throw new NotImplementedException();
    }

    public override bool UnlockUser(string userName)
    {
        throw new NotImplementedException();
    }

    public override void UpdateUser(MembershipUser user)
    {
        throw new NotImplementedException();
    }

    public override bool ValidateUser(string username, string password)
    {
        //var md5Hash = GetMd5Hash(password);
        //var requiredUser = db.NguoiDungs.FirstOrDefault(m=>m.Username == username && m.Password == md5Hash);
        var requiredUser = db.NguoiDungs.FirstOrDefault(m => m.Username == username && m.Password == password);
        return requiredUser != null;
    }

    public static string GetMd5Hash(string value)
    {
        var md5Hasher = MD5.Create();
        var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        var sBuilder = new StringBuilder();
        for (var i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
}