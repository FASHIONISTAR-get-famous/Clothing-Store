﻿using Model.DAO;
using Model.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class ThuongHieuController : Controller
    {
        // GET: Admin/ThuongHieu
        // no tra ve Get du lieu, hom ray tui chi la Post.
        //Ham nay la mac dinh phai co
        //no tra ve return view
        public ActionResult Index()
            // no su dung view bag, hay view data de truyen vao vao view. hieu khong?hieu  noi nghe coi view bag, view data lam sao?dang giai tich cho t ma sao hoi lai tui dạ, noi hieu ma? thi ong noi vay t hieu vayhihi
            //ne qua demo ne

        {
            ViewBag.danhSachThuongHieu = new ThuongHieuDAO().getTatCaThuongHieu();
            return View();
        }

        public JsonResult layThuongHieu(int id)
        {

            var output = JsonConvert.SerializeObject(new ThuongHieuDAO().layThuongHieuTheoID(id),
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });

            return Json(new
            {
                data = output
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(ThuongHieu thuonghieu)
        {
            if (thuonghieu.ID > 0)
            {
                return Json(new
                {
                    //them danh muc
                    status = new ThuongHieuDAO().update(thuonghieu)
                });
            }
            else
            {
                return Json(new
                {
                    //cap nhat danh muc
                    status = new ThuongHieuDAO().insert(thuonghieu)
                });
            }
        }

        public JsonResult Delete(int id)
        {
            return Json(new
            {
                status = new ThuongHieuDAO().delete(id)
            });
        }
    }
}