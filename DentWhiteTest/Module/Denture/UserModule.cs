﻿using DentWhiteTest.Common;
using DentWhiteTest.Contacts;
using DentWhiteTest.TestCase;
using DentWhiteTest.TestCase.Docker;
using TestStack.White.UIItems.WindowItems;
using WhiteFrameDemo.TestCase;

namespace DentWhiteTest.Module.Denture
{
    public class UserModule
    {
        public static void UserAllTest()
        {
            Global.LstInfo.Add("--- 用户管理模块 ---");

            //启动一个客户端
            bool res_Launch = WinHelp.Launch(out Window appWin, out string msg, Const.DenturePath, Const.DentName, Const.DentureId);
            Global.LstInfo.Add(msg);
            if (res_Launch)
            {
                Global.Win_Denture = appWin;

                //启动成功，登录
                var _login = LoginDentureTest.LoginDenture_Success(Global.Win_Denture, out string msg_login);
                Global.LstInfo.Add(msg_login);
                //如果登录失败，返回
                if (!_login) return;
            }
            else
            {
                return;
            }

            #region 用户列表

            //点击用户管理菜单，加载所有用户
            res_Launch = UserTest.Load_UserList(Global.Win_Denture, out string msg1);
            Global.LstInfo.Add(msg1);
            if (!res_Launch) return;

            //输入用户名称，点击查询按钮，加载该用户
            res_Launch = UserTest.Search_UserName(Global.Win_Denture, out string msg2);
            Global.LstInfo.Add(msg2);
            if (!res_Launch) return;

            //用户名称为空，点击查询按钮，加载所有用户
            res_Launch = UserTest.Search_UserNameNull(Global.Win_Denture, out string msg3);
            Global.LstInfo.Add(msg3);
            if (!res_Launch) return;

            #endregion

            #region 新增用户

            //新增用户，账号名称为空
            res_Launch = UserTest.AddUser_UserNameBull(Global.Win_Denture, out string msg4);
            Global.LstInfo.Add(msg4);
            if (!res_Launch) return;

            //新增用户，账号名称最少5个字|多于30个字
            res_Launch = UserTest.AddUser_UserNameLength(Global.Win_Denture, out string msg12);
            Global.LstInfo.Add(msg12);
            if (!res_Launch) return;

            //新增用户，密码为空
            res_Launch = UserTest.AddUser_PwdBull(Global.Win_Denture, out string msg5);
            Global.LstInfo.Add(msg5);
            if (!res_Launch) return;

            //新增用户，密码少于8位|多于30位
            res_Launch = UserTest.AddUser_PwdLength(Global.Win_Denture, out string msg10);
            Global.LstInfo.Add(msg10);
            if (!res_Launch) return;

            //新增用户，邮箱地址格式不正确
            res_Launch = UserTest.AddUser_EmailError(Global.Win_Denture, out string msg6);
            Global.LstInfo.Add(msg6);
            if (!res_Launch) return;

            //新增用户，角色为空
            res_Launch = UserTest.AddUser_RoleNull(Global.Win_Denture, out string msg7);
            Global.LstInfo.Add(msg7);
            if (!res_Launch) return;

            //新增用户，真实姓名为空|真实姓名多于30个字
            res_Launch = UserTest.AddUser_RealNameLength(Global.Win_Denture, out string msg11);
            Global.LstInfo.Add(msg11);
            if (!res_Launch) return;

            //新增用户，真实姓名为空|真实姓名多于30个字
            res_Launch = UserTest.AddUser_IDCard(Global.Win_Denture, out string msg25);
            Global.LstInfo.Add(msg25);
            if (!res_Launch) return;

            //新增用户，真实姓名为空|真实姓名多于30个字
            res_Launch = UserTest.AddUser_Phone(Global.Win_Denture, out string msg26);
            Global.LstInfo.Add(msg26);
            if (!res_Launch) return;

            //新增用户成功，同时关闭新增用户窗口
            res_Launch = UserTest.AddUserSucc(Global.Win_Denture, out string msg8);
            Global.LstInfo.Add(msg8);
            if (!res_Launch) return;

            //新增用户，点击取消按钮，关闭新增用户窗口
            res_Launch = UserTest.AddUser_ClickCancle(Global.Win_Denture, out string msg9);
            Global.LstInfo.Add(msg9);
            if (!res_Launch) return;

            #endregion

            #region 编辑角色

            //编辑用户，账号名称为空
            res_Launch = UserTest.EditUser_UserNameBull(Global.Win_Denture, out string msg13);
            Global.LstInfo.Add(msg13);
            if (!res_Launch) return;

            //编辑用户，账号名称最少5个字符|多于30个字符
            res_Launch = UserTest.EditUser_UserNameLength(Global.Win_Denture, out string msg14);
            Global.LstInfo.Add(msg14);
            if (!res_Launch) return;

            //编辑用户，不修改密码
            res_Launch = UserTest.EditUser_NoEditPwd(Global.Win_Denture, out string msg15);
            Global.LstInfo.Add(msg15);
            if (!res_Launch) return;

            //编辑用户，修改密码为少于8位|多于30位
            res_Launch = UserTest.EditUser_PwdLength(Global.Win_Denture, out string msg16);
            Global.LstInfo.Add(msg16);
            if (!res_Launch) return;

            //编辑用户，邮箱地址格式不正确
            res_Launch = UserTest.EditUser_EmailError(Global.Win_Denture, out string msg17);
            Global.LstInfo.Add(msg17);
            if (!res_Launch) return;

            //编辑用户，修改角色为空
            res_Launch = UserTest.EditUser_EditRole(Global.Win_Denture, out string msg18);
            Global.LstInfo.Add(msg18);
            if (!res_Launch) return;

            //编辑用户，真实姓名为空|真实姓名多于30个字符
            res_Launch = UserTest.EditUser_RealNameLength(Global.Win_Denture, out string msg19);
            Global.LstInfo.Add(msg19);
            if (!res_Launch) return;

            //编辑用户，真实姓名为空|真实姓名多于30个字符
            res_Launch = UserTest.EditUser_IDCard(Global.Win_Denture, out string msg27);
            Global.LstInfo.Add(msg27);
            if (!res_Launch) return;

            //编辑用户，真实姓名为空|真实姓名多于30个字符
            res_Launch = UserTest.EditUser_Phone(Global.Win_Denture, out string msg28);
            Global.LstInfo.Add(msg28);
            if (!res_Launch) return;

            //编辑用户成功，同时关闭编辑用户窗口
            res_Launch = UserTest.EditUserSucc(Global.Win_Denture, out string msg20);
            Global.LstInfo.Add(msg20);
            if (!res_Launch) return;

            //编辑用户，无修改操作，点击确定按钮
            res_Launch = UserTest.EditUser_NoEdit(Global.Win_Denture, out string msg22);
            Global.LstInfo.Add(msg22);
            if (!res_Launch) return;

            //编辑用户，点击取消按钮，关闭编辑用户窗口
            res_Launch = UserTest.EditUser_ClickCancle(Global.Win_Denture, out string msg21);
            Global.LstInfo.Add(msg21);
            if (!res_Launch) return;

            #endregion

            #region 删除用户

            //点击删除用户按钮，弹出提醒框，选择确定
            res_Launch = UserTest.Del_UserComfirm(Global.Win_Denture, out string msg23);
            Global.LstInfo.Add(msg23);
            if (!res_Launch) return;

            //点击删除用户按钮，弹出提醒框，选择取消
            res_Launch = UserTest.Del_UserCancle(Global.Win_Denture, out string msg24);
            Global.LstInfo.Add(msg24);
            if (!res_Launch) return;

            #endregion

            //关闭客户端
            Global.Win_Denture.Close();
        }
    }
}
