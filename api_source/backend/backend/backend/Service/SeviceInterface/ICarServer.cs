using backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Service.SeviceInterface
{
    public interface ICarServer
    {
        IEnumerable<car_view> GetAllTableCar();
        IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, string order_by_price, string name);
        IEnumerable<car_view> GetFavoriteCar(int? customer_id);
        IEnumerable<car_view> GetAllMyCar(int? customer_id);
        IEnumerable<car_view> Getcar(int id);
        Result ChangeStatusCar(car car);
        Task<Result> Postcar(MultipartFormDataStreamProvider fileData);

    }
}
