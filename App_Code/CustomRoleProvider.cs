using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RoleProvider
/// </summary>
public class CustomRoleProvider : System.Web.Security.RoleProvider
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
    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="usernames">a list of usernames</param>
    /// <param name="roleNames">a list of roles</param>
    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
            
        foreach (var user in usernames)
        {
            foreach (var role in roleNames)
            {
                var nd = db.NguoiDungs.FirstOrDefault(m => m.Username == user);
                var qu = db.Quyens.FirstOrDefault(m => m.TenQuyen.ToLower() == role.ToLower());
                db.Quyen_NguoiDungs.InsertOnSubmit(new Quyen_NguoiDung() { NguoiDung = nd, Quyen = qu });
            }
        }
        db.SubmitChanges();
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="roleName">a role name</param>
    public override void CreateRole(string roleName)
    {
        var rl = db.Quyens.FirstOrDefault(m => m.MaQuyen == roleName);
        db.Quyens.InsertOnSubmit(rl);
        db.SubmitChanges();
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="roleName">a role</param>
    /// <param name="throwOnPopulatedRole">get upset of users are in a role</param>
    /// <returns></returns>
    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
        try
        {
            var rl = db.Quyens.FirstOrDefault(m => m.MaQuyen == roleName);
            db.Quyens.DeleteOnSubmit(rl);
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// required implemention
    /// </summary>
    /// <param name="roleName">a role</param>
    /// <param name="usernameToMatch">a username to look for in the role</param>
    /// <returns></returns>
    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
        return (from q in db.Quyen_NguoiDungs
                join u in db.NguoiDungs on q.Username equals u.Username
                select u.Username).ToArray<string>();
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <returns></returns>
    public override string[] GetAllRoles()
    {
        return db.Quyens.Select(m => m.MaQuyen).ToArray<string>();
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="username">a username</param>
    /// <returns>a list of roles</returns>
    public override string[] GetRolesForUser(string username)
    {
        return db.Quyen_NguoiDungs.Where(m => m.Username == username).Select(m => m.MaQuyen).ToArray<string>();
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="roleName">a role</param>
    /// <returns>a list of users</returns>
    public override string[] GetUsersInRole(string roleName)
    {
        return db.Quyen_NguoiDungs.Where(m => m.MaQuyen == roleName).Select(m => m.Username).ToArray<string>();
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="username">a username</param>
    /// <param name="roleName">a role</param>
    /// <returns>true or false</returns>
    public override bool IsUserInRole(string username, string roleName)
    {
        return db.Quyen_NguoiDungs.Count(m => m.Username == username && m.MaQuyen == roleName) > 0;
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="usernames">a list of usernames</param>
    /// <param name="roleNames">a list of roles</param>
    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        foreach (var user in usernames)
        {
            foreach (var role in roleNames)
            {
                var qund = db.Quyen_NguoiDungs.FirstOrDefault(m => m.MaQuyen == role && m.Username == user);
                db.Quyen_NguoiDungs.DeleteOnSubmit(qund);
            }
        }
        db.SubmitChanges();
    }

    /// <summary>
    /// required implementation
    /// </summary>
    /// <param name="roleName">a role</param>
    /// <returns>true or false</returns>
    public override bool RoleExists(string roleName)
    {
        return db.Quyens.Count(m => m.MaQuyen == roleName) > 0;
    }
}