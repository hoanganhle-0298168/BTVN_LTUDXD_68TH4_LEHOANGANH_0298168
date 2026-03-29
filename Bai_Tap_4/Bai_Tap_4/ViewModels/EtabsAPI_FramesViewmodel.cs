using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bai_Tap_4.Models;
using ETABSv1;

namespace Bai_Tap_4.ViewModels
{
    internal class EtabsAPI_FramesViewmodel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //khai báo danh sách phần tử thanh (Frames) để binding với view
        public ObservableCollection<EtabsAPI_Frame> EtabsFrames { get; set; } = new ObservableCollection<EtabsAPI_Frame>();

        #region fields 
        private int _numberNames;
        private string _label;
        private string _myName;
        private string _propName;
        private string _storyName;
        private string _pointName1;
        private string _pointName2;
        private double _point1X;
        private double _point1Y;
        private double _point1Z;
        private double _point2X;
        private double _point2Y;
        private double _point2Z;
        private double _angle;
        private double _offset1X;
        private double _offset2X;
        private double _offset1Y;
        private double _offset2Y;
        private double _offset1Z;
        private double _offset2Z;
        private int _cardinalPoint;
        private double _length;
        #endregion
        #region properties

        public int NumberNames
        {
            get
            {
                return _numberNames;
            }
            set
            {
                _numberNames = value; OnPropertyChanged();
            }
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; OnPropertyChanged(); }

        }
        public string MyName
        {
            get { return _myName; }
            set { _myName = value; OnPropertyChanged(); }

        }

        public string StoryName
        {
            get { return _storyName; }
            set { _storyName = value; OnPropertyChanged(); }
        }

        public string PropName
        {
            get { return _propName; }
            set { _propName = value; OnPropertyChanged(); }
        }

        public string PointName1
        {
            get { return _pointName1; }
            set { _pointName1 = value; OnPropertyChanged(); }
        }

        public string PointName2
        {
            get { return _pointName2; }
            set { _pointName2 = value; OnPropertyChanged(); }
        }

        public double Point1X
        {
            get { return _point1X; }
            set { _point1X = value; OnPropertyChanged(); }
        }

        public double Point1Y
        {
            get { return _point1Y; }
            set { _point1Y = value; OnPropertyChanged(); }
        }

        public double Point1Z
        {
            get { return _point1Z; }
            set { _point1Z = value; OnPropertyChanged(); }
        }


        public double Point2X
        {
            get { return _point2X; }
            set { _point2X = value; OnPropertyChanged(); }
        }

        public double Point2Y
        {
            get { return _point2Y; }
            set { _point2Y = value; OnPropertyChanged(); }
        }

        public double Point2Z
        {
            get { return _point2Z; }
            set { _point2Z = value; OnPropertyChanged(); }
        }

        public double Angle
        {
            get { return _angle; }
            set { _angle = value; OnPropertyChanged(); }
        }


        public double Offset1X
        {
            get { return _offset1X; }
            set { _offset1X = value; OnPropertyChanged(); }
        }


        public double Offset2X
        {
            get { return _offset2X; }
            set { _offset2X = value; OnPropertyChanged(); }
        }

        public double Offset1Y
        {
            get { return _offset1Y; }
            set { _offset1Y = value; OnPropertyChanged(); }
        }

        public double Offset2Y
        {
            get { return _offset2Y; }
            set { _offset2Y = value; OnPropertyChanged(); }
        }

        public double Offset1Z
        {
            get { return _offset1Z; }
            set { _offset1Z = value; OnPropertyChanged(); }
        }


        public double Offset2Z
        {
            get { return _offset2Z; }
            set { _offset2Z = value; OnPropertyChanged(); }
        }

        public int CardinalPoint
        {
            get { return _cardinalPoint; }
            set { _cardinalPoint = value; OnPropertyChanged(); }
        }

        public double Length
        {
            get
            {

                return Math.Sqrt(Math.Pow((Point2X - Point1X), 2) + Math.Pow((Point2Y - Point1Y), 2) + Math.Pow((Point2Z - Point1Z), 2)); ;
            }
            set { _length = value; OnPropertyChanged(); }
        }

        #endregion

        //khai báo command

        //hàm khởi tạo của EtabsAPI_FramesViewmodel
        public EtabsAPI_FramesViewmodel()
        {
            //gọi hàm lấy dữ liệu Frame từ Etabs API
            ETABSAPI_GetallFrame();
        }
        //Viết phương thức lấy dữ liệu từ Etabs API
        public void ETABSAPI_GetallFrame()
        {
          
        }
    }
}
