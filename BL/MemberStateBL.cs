using System;
using System.Linq;
using DomainClasses.Models;

namespace BL
{
    //=====================================================================================
    public class MemberStatePrepareBL
    {
        MemberBL _MemberBL = new MemberBL();

        public bool SetMemberState(string username)
        {
            try
            {
                MemberState state = new MemberState();              
                                        
                //......................................... get Member by UserName
               // MemberSC memCriteria = new MemberSC(true);
               // memCriteria.UserName = username;
               // members = _MemberBL.GetByCriteria(memCriteria, null, null);
                
               

               // if (members != null && members.Count > 0)
               //{
               //     //state.CountryCode = state.Member.CountryCode == null ? LocalizationUtil.DefaultCountry : state.Member.CountryCode;
               //     //state.CultureCode = LocalizationUtil.CheckCulture(state.Member.CultureCode);
               //     //................................................
               //     MemberStateBL.State = state;
               //     //................................................

                return true;
            }
            catch (Exception ex)
            {
                MemberStateBL.State.Message = ex.ToString(); // .Message;
                return false;
            }
        }        
    }
    public static class MemberStateBL
    {
        public static MemberState State
        {
            get
            {
                if (System.Web.HttpContext.Current != null
                    && System.Web.HttpContext.Current.Session != null
                    && System.Web.HttpContext.Current.Session["membState"] != null)
                {
                    return ((MemberState)System.Web.HttpContext.Current.Session["membState"]);
                }
                else
                    return new MemberState();
            }
            set
            {
                System.Web.HttpContext.Current.Session["membState"] = value;
            }
        }       
    }
    //=====================================================================================
    public class MemberState
    {
        private string _UserName = null;

        public string CultureCode { get; set; }
        public string CountryCode { get; set; }        
        //public SettingsVO Settings { get; set; }      
        public Member member = new Member();
        public string Message { get; set; }
        //..........................................................................Security
        public string[] Roles { get; set; }

        public bool IsUserInRole(string roleName)
        {
            return Roles != null && Roles.Contains(roleName);
        }
       
        public string DisplayUserName { get; set; }

        public string UserName
        {
            get
            {
                if (_UserName == null && System.Web.HttpContext.Current.User.Identity.Name != null)
                    _UserName = System.Web.HttpContext.Current.User.Identity.Name;

                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }               
    }
}