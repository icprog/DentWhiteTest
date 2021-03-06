﻿using DentWhiteTest.Common;
using DentWhiteTest.Contacts;
using DentWhiteTest.TestCase;
using DentWhiteTest.TestCase.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.WindowItems;
using WhiteFrameDemo.TestCase;

namespace DentWhiteTest.Module.Denture
{
    /// <summary>
    /// 医生管理模块
    /// </summary>
    public class DoctorManageModule
    {
        /// <summary>
        /// 医生管理员登录 医生管理测试
        /// </summary>
        public static void DoctorAdmin_DoctorManageAllTest()
        {
            Global.LstInfo.Add("--- （医生管理员端）医生管理模块 ---");

            //启动一个客户端
            bool res_Launch = WinHelp.Launch(out Window appWin, out string msg, Const.DoctorPath, Const.DoctorClientName, Const.DoctorId);
            Global.LstInfo.Add(msg);
            if (res_Launch)
            {
                Global.Win_Dentlab = appWin;

                //启动成功，登录
                var _login = LoginDoctorTest.LoginSuperDoctor_Success(Global.Win_Dentlab, out string msg_login);
                Global.LstInfo.Add(msg_login);
                //如果登录失败，返回
                if (!_login) return;
            }
            else
            {
                return;
            }

            var d = DoctorManageTest(res_Launch);
            if (d)
            {
                //关闭客户端
                Global.Win_Dentlab.Close();
            }
        }

        /// <summary>
        /// 技工厂登录 医生管理测试
        /// </summary>
        public static void Factory_DoctorManageAllTest()
        {
            Global.LstInfo.Add("--- （技工厂端）医生管理模块 ---");

            //启动一个客户端
            bool res_Launch = WinHelp.Launch(out Window appWin, out string msg, Const.DoctorPath, Const.DoctorClientName, Const.DoctorId);
            Global.LstInfo.Add(msg);
            if (res_Launch)
            {
                Global.Win_Dentlab = appWin;

                //启动成功，登录
                var _login = LoginDoctorTest.LoginFactory_Success(Global.Win_Dentlab, out string msg_login);
                Global.LstInfo.Add(msg_login);
                //如果登录失败，返回
                if (!_login) return;
            }
            else
            {
                return;
            }

            var d = DoctorManageTest(res_Launch);
            if (d)
            {
                //技工厂有匹配技师权限
                var m = MatchingTechnicianTest(d);
                if (m)
                {
                    //关闭客户端
                    Global.Win_Dentlab.Close();
                }
            }
        }

        /// <summary>
        /// 医生管理测试
        /// </summary>
        public static bool DoctorManageTest(bool res_Launch)
        {
            #region 医生列表

            //点击医生管理菜单，加载所有医生
            res_Launch = DoctorManagerTest.Load_DoctorList(Global.Win_Dentlab, out string msg1);
            Global.LstInfo.Add(msg1);
            if (!res_Launch) return false;

            //输入账号名，点击查询按钮，加载该医生
            res_Launch = DoctorManagerTest.Search_DoctoruserName(Global.Win_Dentlab, out string msg2);
            Global.LstInfo.Add(msg2);
            if (!res_Launch) return false;

            //输入医生名称，点击查询按钮，加载该医生
            res_Launch = DoctorManagerTest.Search_DoctorName(Global.Win_Dentlab, out string msg3);
            Global.LstInfo.Add(msg3);
            if (!res_Launch) return false;

            //选择是否在线，点击查询按钮，加载是否在线医生
            res_Launch = DoctorManagerTest.Search_DoctorUnOnline(Global.Win_Dentlab, out string msg4);
            Global.LstInfo.Add(msg4);
            if (!res_Launch) return false;

            //医生名称为空，点击查询按钮，加载所有医生
            res_Launch = DoctorManagerTest.Search_DoctorNameNull(Global.Win_Dentlab, out string msg5);
            Global.LstInfo.Add(msg5);
            if (!res_Launch) return false;

            #endregion

            #region 新增医生
            //新增医生，账号名为空
            res_Launch = DoctorManagerTest.AddDoctor_DoctorNameNull(Global.Win_Dentlab, out string msg6);
            Global.LstInfo.Add(msg6);
            if (!res_Launch) return false;

            //新增医生，账号名称最少5个字 | 多于30个字
            res_Launch = DoctorManagerTest.AddDoctor_DoctorNameLength(Global.Win_Dentlab, out string msg7);
            Global.LstInfo.Add(msg7);
            if (!res_Launch) return false;

            //新增医生，密码为空
            res_Launch = DoctorManagerTest.AddDoctor_PwdBull(Global.Win_Dentlab, out string msg8);
            Global.LstInfo.Add(msg8);
            if (!res_Launch) return false;

            //新增医生，密码少于8位|多于30位
            res_Launch = DoctorManagerTest.AddDoctor_PwdLength(Global.Win_Dentlab, out string msg9);
            Global.LstInfo.Add(msg9);
            if (!res_Launch) return false;

            // 新增医生，邮箱地址格式不正确
            res_Launch = DoctorManagerTest.AddDoctor_EmailError(Global.Win_Dentlab, out string msg10);
            Global.LstInfo.Add(msg10);
            if (!res_Launch) return false;

            // 新增医生，真实姓名为空|真实姓名多于30个字
            res_Launch = DoctorManagerTest.AddDoctor_RealNameLength(Global.Win_Dentlab, out string msg13);
            Global.LstInfo.Add(msg13);
            if (!res_Launch) return false;

            // 新增医生，身份证为空|身份证格式错误
            res_Launch = DoctorManagerTest.AddDoctor_IDCard(Global.Win_Dentlab, out string msg30);
            Global.LstInfo.Add(msg30);
            if (!res_Launch) return false;

            // 新增用户，医院为空
            res_Launch = DoctorManagerTest.AddDoctor_HospitalNull(Global.Win_Dentlab, out string msg11);
            Global.LstInfo.Add(msg11);
            if (!res_Launch) return false;

            // 新增医生，手机为空|手机格式错误
            res_Launch = DoctorManagerTest.AddDoctor_Phone(Global.Win_Dentlab, out string msg31);
            Global.LstInfo.Add(msg31);
            if (!res_Launch) return false;

            // 新增医生，市场负责人为空
            res_Launch = DoctorManagerTest.AddDoctor_MarkerNull(Global.Win_Dentlab, out string msg32);
            Global.LstInfo.Add(msg32);
            if (!res_Launch) return false;

            // 新增医生成功，同时关闭新增医生窗口
            res_Launch = DoctorManagerTest.AddDoctorSucc(Global.Win_Dentlab, out string msg12);
            Global.LstInfo.Add(msg12);
            if (!res_Launch) return false;

            // 新增医生，点击取消按钮，关闭新增医生窗口
            res_Launch = DoctorManagerTest.AddDoctor_ClickCancle(Global.Win_Dentlab, out string msg14);
            Global.LstInfo.Add(msg14);
            if (!res_Launch) return false;
            #endregion

            #region 编辑医生
            //编辑医生，账号名为空
            res_Launch = DoctorManagerTest.EditDoctor_DoctorNameNull(Global.Win_Dentlab, out string msg15);
            Global.LstInfo.Add(msg15);
            if (!res_Launch) return false;

            //编辑医生，账号名称最少5个字|多于30个字
            res_Launch = DoctorManagerTest.EditDoctor_DoctorNameLength(Global.Win_Dentlab, out string msg16);
            Global.LstInfo.Add(msg16);
            if (!res_Launch) return false;

            //编辑医生，不修改密码
            res_Launch = DoctorManagerTest.EditDoctor_NoEditPwd(Global.Win_Dentlab, out string msg17);
            Global.LstInfo.Add(msg17);
            if (!res_Launch) return false;

            //编辑医生，修改密码为少于8位|多于30位
            res_Launch = DoctorManagerTest.EditDoctor_PwdLength(Global.Win_Dentlab, out string msg18);
            Global.LstInfo.Add(msg18);
            if (!res_Launch) return false;

            //编辑医生，邮箱地址格式不正确
            res_Launch = DoctorManagerTest.EditDoctor_EmailError(Global.Win_Dentlab, out string msg19);
            Global.LstInfo.Add(msg19);
            if (!res_Launch) return false;

            //编辑医生，真实姓名为空|真实姓名多于30个字
            res_Launch = DoctorManagerTest.EditDoctor_RealNameLength(Global.Win_Dentlab, out string msg20);
            Global.LstInfo.Add(msg20);
            if (!res_Launch) return false;

            //编辑医生，身份证为空|身份证格式错误
            res_Launch = DoctorManagerTest.EditDoctor_IDCard(Global.Win_Dentlab, out string msg33);
            Global.LstInfo.Add(msg33);
            if (!res_Launch) return false;

            //编辑医生，手机为空|手机格式错误
            res_Launch = DoctorManagerTest.EditDoctor_Phone(Global.Win_Dentlab, out string msg34);
            Global.LstInfo.Add(msg34);
            if (!res_Launch) return false;

            //编辑医生，修改所在医院
            res_Launch = DoctorManagerTest.EditDoctor_EditHospital(Global.Win_Dentlab, out string msg21);
            Global.LstInfo.Add(msg21);
            if (!res_Launch) return false;

            //编辑医生，修改市场负责人
            res_Launch = DoctorManagerTest.EditDoctor_Marker(Global.Win_Dentlab, out string msg22);
            Global.LstInfo.Add(msg22);
            if (!res_Launch) return false;

            //编辑医生成功，同时关闭编辑医生窗口
            res_Launch = DoctorManagerTest.EditDoctorSucc(Global.Win_Dentlab, out string msg23);
            Global.LstInfo.Add(msg23);
            if (!res_Launch) return false;

            //编辑医生，无修改操作，点击确定按钮
            res_Launch = DoctorManagerTest.EditDoctor_NoEdit(Global.Win_Dentlab, out string msg24);
            Global.LstInfo.Add(msg24);
            if (!res_Launch) return false;

            //编辑医生，点击取消按钮，关闭编辑医生窗口
            res_Launch = DoctorManagerTest.EditDoctor_ClickCancle(Global.Win_Dentlab, out string msg25);
            Global.LstInfo.Add(msg25);
            if (!res_Launch) return false;

            #endregion

            #region 删除医生
            //点击删除医生按钮，弹出提醒框，选择确定
            res_Launch = DoctorManagerTest.Del_DoctorComfirm(Global.Win_Dentlab, out string msg26);
            Global.LstInfo.Add(msg26);
            if (!res_Launch) return false;

            //点击删除医生按钮，弹出提醒框，选择取消
            res_Launch = DoctorManagerTest.Del_DoctorCancle(Global.Win_Dentlab, out string msg27);
            Global.LstInfo.Add(msg27);
            if (!res_Launch) return false;

            return true;

            #endregion
        }

        /// <summary>
        /// 匹配技师测试
        /// </summary>
        public static bool MatchingTechnicianTest(bool res_Launch)
        {
            //击匹配技师按钮，弹出提醒框，选择确定
            res_Launch = DoctorManagerTest.MatchingTechnician_Succ(Global.Win_Dentlab, out string msg28);
            Global.LstInfo.Add(msg28);
            if (!res_Launch) return false;
            //不选择技师，直接点击确定
            res_Launch = DoctorManagerTest.MatchingTechnician_Null(Global.Win_Dentlab, out string msg29);
            Global.LstInfo.Add(msg29);
            if (!res_Launch) return false;

            return true;
        }
    }
}
