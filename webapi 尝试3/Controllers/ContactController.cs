using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi_尝试3.Models;
namespace webapi_尝试3.Controllers
{
    public class ContactController : ApiController
    {
        //合同

        Contact[] contacts = new Contact[]
        {
             new Contact(){ ID=1, Age=23, Birthday=Convert.ToDateTime("1977-05-30"), Name="情缘", Sex="男"},
            new Contact(){ ID=2, Age=55, Birthday=Convert.ToDateTime("1937-05-30"), Name="令狐冲", Sex="男"},
            new Contact(){ ID=3, Age=12, Birthday=Convert.ToDateTime("1987-05-30"), Name="郭靖", Sex="男"},
            new Contact(){ ID=4, Age=18, Birthday=Convert.ToDateTime("1997-05-30"), Name="黄蓉", Sex="女"},
        };


        //Get /api/contact  获取 任务列表
        public IEnumerable<Contact> GetListAll()
        {
            return contacts;
        }

        //Get /api/contact/id  通过id 获取人物
        public Contact GetContactById(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(item=>item.ID==id);

            if(contact==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return contact;
        }


        ///根据性别查询
      //  /api/Contact? sex=女
      
        public IEnumerable<Contact> GetListBySex(string sex)
        {
            return contacts.Where(item=>item.Sex==sex);
        }



    }
}
