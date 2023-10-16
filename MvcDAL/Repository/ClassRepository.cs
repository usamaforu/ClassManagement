using APIDTOs;
using MvcDAL.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDAL.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly HttpClient _httpClient;
        public ClassRepository(HttpClient client)
        {
            _httpClient = client;
        }
        public void AddClass(ClassDTOs classDTOs)
        {
            try
            {

                String data = JsonConvert.SerializeObject(classDTOs);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage message = _httpClient.PostAsync(_httpClient.BaseAddress + "Class/addclass", content).Result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ClassDTOs>> GetAllClasses()
        {
            try
            {
                var response = await _httpClient.GetAsync("Class/GetAllClasses");
                if (!response.IsSuccessStatusCode) return new List<ClassDTOs>();
                string result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ClassDTOs>>(result);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ClassDTOs>> GetAllClassesWithoutStudent()
        {
            try
            {
                var response = await _httpClient.GetAsync("class/GetClassesWithoutStudent");
                if (!response.IsSuccessStatusCode) return new List<ClassDTOs>();
                string result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ClassDTOs>>(result);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteClass(int id)
        {
            var response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "Class/DeleteClass?id=" + id).Result; 
        }

        public async Task<ClassDTOs> GetClassById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync("class/GetClassById?id=" + id);
                if (!response.IsSuccessStatusCode) return new ClassDTOs();
                string result = await response.Content.ReadAsStringAsync();
                var classs = JsonConvert.DeserializeObject<ClassDTOs>(result);
                return classs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateClass(ClassDTOs classDTOs)
        {
            try
            {
                string data = JsonConvert.SerializeObject(classDTOs);
                StringContent content = new StringContent(data, Encoding.UTF8, "Application/json");
                HttpResponseMessage message = _httpClient.PutAsync(_httpClient.BaseAddress + "class/UpdateClass",content).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
