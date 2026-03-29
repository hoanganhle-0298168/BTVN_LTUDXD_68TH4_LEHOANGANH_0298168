using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ON_TAP_GK.Models;

namespace ON_TAP_GK.ViewModels
{
    public class BeamViewModel : INotifyPropertyChanged
    {

        // Bước 1: Khai báo sự kiện PropertyChanged để thông báo khi có sự thay đổi trong dữ liệu
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // Bước 2: Khai báo  danh sách dầm để hiển thị trong giao diện người dùng
        public ObservableCollection<BeamModel> BeamList { get; set; } = new ObservableCollection<BeamModel>();

        // Bước 3: Khai báo dầm hiện tại
        public BeamModel CurrentBeam { get; set; } = new BeamModel();

        // Bước 4: Khai báo danh sách vật liệu để đưa vào combo box
        public ObservableCollection<ConcreteMaterialModel> ConcreteMaterialList { get; set; } = new ObservableCollection<ConcreteMaterialModel>();
        public ObservableCollection<RebarMaterialModel> RebarMaterialList { get; set; } = new ObservableCollection<RebarMaterialModel>();

        // Bước 5: Khai báo các thành phần  (fields, properties, methods) để xử lý logic cho view
        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private string _mark;
        public string Mark
        {
            get => _mark;
            set { _mark = value; OnPropertyChanged(); }
        }

        private double _b;
        public double b
        {
            get => _b;
            set { _b = value; OnPropertyChanged(); }
        }

        private double _h;
        public double h
        {
            get => _h;
            set { _h = value; OnPropertyChanged(); }
        }

        private double _a;
        public double a
        {
            get => _a;
            set { _a = value; OnPropertyChanged(); }
        }

        private double _h0;
        public double h0
        {
            get => _h0;
            set { _h0 = value; OnPropertyChanged(); }
        }

        private double _m;
        public double M
        {
            get => _m;
            set { _m = value; OnPropertyChanged(); }
        }

        private ConcreteMaterialModel _concreteMaterial;
        public ConcreteMaterialModel ConcreteMaterial
        {
            get => _concreteMaterial;
            set { _concreteMaterial = value; OnPropertyChanged(); }
        }

        private RebarMaterialModel _rebarMaterial;
        public RebarMaterialModel RebarMaterial
        {
            get => _rebarMaterial;
            set { _rebarMaterial = value; OnPropertyChanged(); }
        }

        private double _alphaM;
        public double AlphaM
        {
            get => _alphaM;
            set { _alphaM = value; OnPropertyChanged(); }
        }

        private double _alphaR;
        public double AlphaR
        {
            get => _alphaR;
            set { _alphaR = value; OnPropertyChanged(); }
        }

        private double _xi;
        public double Xi
        {
            get => _xi;
            set { _xi = value; OnPropertyChanged(); }
        }

        private double _xiR;
        public double XiR
        {
            get => _xiR;
            set { _xiR = value; OnPropertyChanged(); }
        }
        private double _as;
        public double As
        {
            get => _as;
            set { _as = value; OnPropertyChanged(nameof(As)); }
        }

        private double _mu;
        public double Mu
        {
            get => _mu;
            set { _mu = value; OnPropertyChanged(); }
        }

        private string _baitoan;
        public string BaiToan
        {
            get => _baitoan;
            set { _baitoan = value; OnPropertyChanged(nameof(BaiToan)); }
        }

        // Bước 6: Khai báo command
        public ICommand AddBeamCommand { get; }
        public ICommand CalBeamCommand { get; }
        public ICommand RemoveBeamCommand { get; }

        //Bước 7: Viết hàm khởi tạo 
        public BeamViewModel()
        {
            //Khởi tạo danh sách vật liệu bê tông
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B20", Rb = 11.5, Rbt = 0.9, Eb = 27500 });
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B25", Rb = 14.5, Rbt = 1.05, Eb = 30000 });
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B30", Rb = 17, Rbt = 1.15, Eb = 32500 });
            //khởi tạo danh sách vật liệu cốt thép
            RebarMaterialList.Add(new RebarMaterialModel { Name = "CB300-V", Rs = 260, Rsc = 260 });
            RebarMaterialList.Add(new RebarMaterialModel { Name = "CB400-V", Rs = 350, Rsc = 350 });
            //Khởi tạo Command
            AddBeamCommand = new RelayCommand(AddBeamMethod);
            CalBeamCommand = new RelayCommand(CalBeamMethod);
            RemoveBeamCommand = new RelayCommand(RemoveBeamMethod);
        }

        // Bước 8: Viết các phương thức xử lý logic cho command

        private void RemoveBeamMethod()
        {
            //dầm đang chọn select trong datagrid là CurrentBeam, nên ta sẽ xóa CurrentBeam khỏi BeamList
            // Cú pháp: (Doi_Tuong != null && Ten_Danh_Sach.Contains(Doi_Tuong))
            // "CurrentBeam != null": Đảm bảo người dùng đã bấm chọn một dầm trên giao diện (nếu chưa chọn gì thì CurrentBeam sẽ bị rỗng hay null).
            // "BeamList.Contains(CurrentBeam)": Kiểm tra xem đối tượng dầm đang được chọn (CurrentBeam) có thực sự tồn tại trong danh sách BeamList hay không.
            if (CurrentBeam != null && BeamList.Contains(CurrentBeam))
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa dầm {CurrentBeam.Mark}?",
                    "Xác nhận",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    BeamList.Remove(CurrentBeam);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dầm cần xóa trong danh sách.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddBeamMethod()
        {
            // Khởi tạo một đối tượng mới 
            BeamModel _newbeam = new BeamModel();

            // Gán các giá trị từ giao diện (VM) cho các thuộc tính dầm cột 
            _newbeam.Mark = Mark;
            _newbeam.b = b;
            _newbeam.h = h;
            _newbeam.a = a;
            _newbeam.M = M;
            _newbeam.ConcreteMaterial = ConcreteMaterial;
            _newbeam.RebarMaterial = RebarMaterial;
            _newbeam.Id = BeamList.Count + 1;
            _newbeam.h0 = _newbeam.h - _newbeam.a;
            _newbeam.AlphaR = 0.371;
            _newbeam.XiR = 0.493;

            // Kiểm tra xem mã hiệu dầm đã tồn tại trong danh sách chưa
            // Hàm Any() sẽ duyệt qua BeamList xem có dầm nào (b) có Mark giống vơi Mark của _newbeam hay không
            // Cú pháp: (Ten_Danh_Sach.Any(b => b.Thuoc_Tinh_So_Sanh == Gia_Tri_So_Sanh)) 
            // b là một tên biến tạm dùng để đại diện cho từng đối tượng dầm (BeamModel) nằm bên trong danh sách BeamList khi hàm Any duyệt qua.
            if (BeamList.Any(b => b.Mark == _newbeam.Mark))
            {
                //hiển thị thông báo lỗi nếu mã hiệu trùng
                System.Windows.MessageBox.Show("Mã hiệu dầm đã tồn tại. Vui lòng nhập mã hiệu khác.", "Lỗi", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            else
            {
                //thêm dầm hiện tại vào danh sách dầm BeamList
                BeamList.Add(_newbeam);
            }
        }

        private void CalBeamMethod()
        {
            if (BeamList.Count > 0)
            {
                foreach (var beam in BeamList)
                {
                    //gọi hàm tính toán As dầm
                    TinhToanAs(beam);
                }

                MessageBox.Show("Đã tính toán xong cho tất cả các dầm trong danh sách.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void TinhToanAs(BeamModel beam)  //xem sơ đồ khối rồi mình code theo thuật toán
        {

        }


    }
}
