using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauDuAn_CTThietKeDam.Models
{
    public class Beam
    {
       #region Fields
       private string _id;
       private string _mark; //mã hiệu
       private string _story; //tầng
       private double _length; //chiều dài
       private double _volume; //thể tích
       //khai báo quan hệ 1-1 của beam và frameEtabs
       private EtabsAPI_Frame _frame;
        #endregion
        //properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }
        public string Story
        {
            get { return _story; }
            set { _story = value; }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public double Volume
        {
            get { return _volume; }
            set { _volume = value;}
        }
        public EtabsAPI_Frame Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        //constructor - hàm khởi tạo
        Beam(string id, string mark, string story)
        {
            _id = id;
            _mark = mark;
            _story = story;
        }

        //method
        //Kiểm tra TTGH thứ nhất của dầm
        public bool CheckTTGH1()
        {
            
            return false;
        }
    }
}
