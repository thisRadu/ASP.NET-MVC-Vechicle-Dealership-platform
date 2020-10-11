using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar.Models
{
    public class Main
    {
        public static List<CarModel> cars = new List<CarModel>();
    
        public static List<CarModel> GetCars()
        {
            cars = DatabaseOperation.FetchAllCars();
            return cars;
        }
        public static CarModel GetCarById(int id)
        {
            CarModel car = new CarModel();
            foreach (CarModel x in cars)
            {
                if (x.Id == id) { car = x; break; }
            }
            return car;
        }
        public static void RemoveCar(int id)
        {
            CarModel car = GetCarById(id);
            DatabaseOperation.RemoveCarFromDatabase(car);
            cars.Remove(car);

        }
        public static SelectList GetAllImagees()
        { 
            List<ImageModel> img = new List<ImageModel>();
            img.Add(new ImageModel { Url =" /Img/audia4.jpg" , Name = "Audi"});
            img.Add(new ImageModel { Url = "/Img/dacia.jpg", Name = "Dacia" });
            img.Add(new ImageModel { Url = "/Img/bmw.jpg", Name = "BMW" });
            img.Add(new ImageModel { Url = "/Img/skoda.jpg", Name = "Skoda" });
            img.Add(new ImageModel { Url = "/Img/fiat.jpg", Name = "Fiat" });
            SelectList objselectlist = new SelectList(img, "Url", "Name");
            return objselectlist;
        }
    }
}
