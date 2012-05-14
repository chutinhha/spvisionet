using System;
using System.Reflection;
using System.Resources;

namespace SPVisionet.CorporateSecretary.Common
{
    public class SR
    {
        public static string SaveSuccess
        {
            get
            {
                return Keys.GetString(Keys.SaveSuccess);
            }
        }

        public static string UpdateSuccess
        {
            get
            {
                return Keys.GetString(Keys.UpdateSuccess);
            }
        }

        public static string DeleteSuccess
        {
            get
            {
                return Keys.GetString(Keys.DeleteSuccess);
            }
        }

        public static string DeleteFail
        {
            get
            {
                return Keys.GetString(Keys.DeleteFail);
            }
        }

        public static string SaveFail
        {
            get
            {
                return Keys.GetString(Keys.SaveFail);
            }
        }

        public static string UpdateFail
        {
            get
            {
                return Keys.GetString(Keys.UpdateFail);
            }
        }

        public static string InvalidData
        {
            get
            {
                return Keys.GetString(Keys.InvalidData);
            }
        }

        public static string DataIsExist(string dataName)
        {
            return Keys.GetString(Keys.DataIsExist, new object[] {
                        dataName});
        }

        public static string IntegerData(string dataName)
        {
            return Keys.GetString(Keys.IntegerData, new object[] {
                        dataName});
        }

        public static string FieldCanNotEmpty(string dataName)
        {
            return Keys.GetString(Keys.FieldCanNotEmpty, new object[] {
                        dataName});
        }

        public static string AttachmentFailed(string dataName)
        {
            return Keys.GetString(Keys.AttachmentFailed, new object[] {
                        dataName});
        }

        public class Keys
        {

            static System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("SPVisionet.CorporateSecretary.Common.SR", typeof(SR).Assembly);

            public const string DataIsExist = "DataIsExist";

            public const string DeleteFail = "DeleteFail";

            public const string SaveFail = "SaveFail";

            public const string UpdateFail = "UpdateFail";

            public const string IntegerData = "IntegerData";

            public const string FieldCanNotEmpty = "FieldCanNotEmpty";

            public const string SaveSuccess = "SaveSuccess";

            public const string UpdateSuccess = "UpdateSuccess";

            public const string DeleteSuccess = "DeleteSuccess";

            public const string InvalidData = "InvalidData";

            public const string AttachmentFailed = "AttachmentFailed";

            public static string GetString(string key)
            {
                return resourceManager.GetString(key, System.Globalization.CultureInfo.CurrentCulture);
            }

            public static string GetString(string key, object[] args)
            {
                string msg = resourceManager.GetString(key, System.Globalization.CultureInfo.CurrentCulture);
                msg = string.Format(msg, args);
                return msg;
            }
        }
    }
}
