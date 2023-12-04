using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT2022232.WpfClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static EZUJIA_HFT_2022232.Logic.CarsLogic;
using static EZUJIA_HFT_2022232.Logic.RentLogic;

namespace EZUJIA_HFT2022232.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<CarBrand> Carbrand { get; set; }

        public RestCollection<Cars> cars { get; set; }

        public RestCollection<Rent> rents { get; set; }


        public List<TheMostFamous> themostfamous { get; set; }

        public List<string> therentscarbrand { get; set; }

        public List<BrandperRentsCount> brandperRentsCounts { get; set; }

        public List<AvarageCarHP> avarageCarHPs { get; set; }


        public List<YearInfo> yearInfos { get; set; }





        public ICommand CreateCarBrandCommand { get; set; }

        public ICommand DeleteCarBrandCommand { get; set; }

        public ICommand UpdateCrandBrandCommand { get; set; }


        public ICommand CreateCarCommand { get; set; }

        public ICommand DeleteCarCommand { get; set; }

        public ICommand UpdateCrandCommand { get; set; }


        public ICommand CreateRentCarCommand { get; set; }

        public ICommand DeleteRentCarCommand { get; set; }

        public ICommand UpdateRentCarCommand { get; set; }

        private CarBrand selectedCarBrand;

        public CarBrand SelectedCarBrand
        {
            get { return selectedCarBrand; }
            set
            {
                SetProperty(ref selectedCarBrand, value);
                //if (value != null)
                //{
                //    selectedCarBrand = new CarBrand()
                //    {
                //        Name = value.Name,
                //        CarBrandID = value.CarBrandID
                //    };
                //    OnPropertyChanged();
                    (DeleteCarBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }



            }
        
        private Cars selectedCar;

        public Cars SelectedCar
        {
            get { return selectedCar; }

            set

            {
                if (value != null)
                {
                    selectedCar = new Cars()
                    {
                        LicensePlateNumber = value.LicensePlateNumber,
                        PerformanceInHP = value.PerformanceInHP,
                        CarBrandId = value.CarBrandId,
                        Type = value.Type,
                        Year = value.Year,
                        CarsId = value.CarBrandId,

                    };
                    OnPropertyChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        private Rent selectedRentitem;

        public Rent SelectedRentitem
        {
            get { return selectedRentitem; }
            set
            {
                if (value != null)
                {
                    selectedRentitem = new Rent()
                    {
                        RentId = value.RentId,
                        RentTime = value.RentTime,
                        CarsId = value.CarsId,
                        OwnerName = value.OwnerName,

                    };
                    OnPropertyChanged();
                    (DeleteRentCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }



        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {

            Carbrand = new RestCollection<CarBrand>("http://localhost:63234/", "carbrand", "hub");
            CreateCarBrandCommand = new RelayCommand(() =>
            {
                Carbrand.Add(new CarBrand()
                {
                    Name = SelectedCarBrand.Name
                });
            });
            UpdateCrandBrandCommand = new RelayCommand(() =>
            {
                Carbrand.Update(SelectedCarBrand);
            });

            DeleteCarBrandCommand = new RelayCommand(() =>
            {
                Carbrand.Delete(SelectedCarBrand.CarBrandID);
            },
            () =>
            {
                return SelectedCarBrand != null;
            });
            SelectedCarBrand = new CarBrand();


            cars = new RestCollection<Cars>("http://localhost:63234/", "cars", "hub");
            rents = new RestCollection<Rent>("http://localhost:63234/", "rent", "hub");
            //themostfamous = new RestCollection<TheMostFamous>("http://localhost:63234/", "CrudMethod/TheMostFamousBrand");
            themostfamous = new RestService("http://localhost:63234/").Get<TheMostFamous>("CrudMethod/TheMostFamousBrand");
            therentscarbrand = new RestService("http://localhost:63234/").Get<string>("CrudMethod/TheRentsCarBrand");
            brandperRentsCounts = new RestService("http://localhost:63234/").Get<BrandperRentsCount>("CrudMethod/BrandperRentsCountsMethod");
            avarageCarHPs = new RestService("http://localhost:63234/").Get<AvarageCarHP>("CrudMethod/AvarageHPperCar");
            yearInfos = new RestService("http://localhost:63234/").Get<YearInfo>("CrudMethod/YearStatistics");




            
            //-----------------------------------------------------------

            CreateCarCommand = new RelayCommand(() =>
            {
                cars.Add(new Cars()
                {
                    LicensePlateNumber = SelectedCar.LicensePlateNumber,
                    PerformanceInHP = SelectedCar.PerformanceInHP,
                    CarBrandId = SelectedCar.CarBrandId,
                    Type = SelectedCar.Type,
                    Year = SelectedCar.Year
                });
            });


            UpdateCrandCommand = new RelayCommand(() =>
            {
                cars.Update(SelectedCar);
            });

            DeleteCarCommand = new RelayCommand(() =>
            {
                cars.Delete(SelectedCar.CarsId);
            },
            () =>
            {
                return SelectedCar != null;
            });

            //---------------------------------------------------------
            CreateRentCarCommand = new RelayCommand(() =>
            {
                rents.Add(new Rent()
                {
                    CarsId = SelectedRentitem.CarsId,
                    OwnerName = SelectedRentitem.OwnerName,
                    RentTime = SelectedRentitem.RentTime,
                    //RentId = SelectedRentitem.RentId,
                });
            });


            UpdateRentCarCommand = new RelayCommand(() =>
            {
                rents.Update(SelectedRentitem);
            });

            DeleteRentCarCommand = new RelayCommand(() =>
            {
                rents.Delete(SelectedRentitem.RentId);
            },
            () =>
            {
                return selectedRentitem != null;
            });



            SelectedRentitem = new Rent();
            SelectedCar = new Cars();
            //SelectedCarBrand = new CarBrand();







        }
    }

    public class Therentscarbrand
    {
        public string Name { get; set; }
    }
}

    
    
