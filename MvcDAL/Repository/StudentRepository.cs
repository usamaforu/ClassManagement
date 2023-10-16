using APIDTOs;
using MvcDAL.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace MvcDAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HttpClient _httpClient;

        public StudentRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void AddStudent(StudentDTOs studentDTOs)
        {
            try
            {
                string data = JsonConvert.SerializeObject(studentDTOs);
                StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
                HttpResponseMessage responseMessage = _httpClient.PostAsync(_httpClient.BaseAddress + "Student/AddStudent", content).Result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {

                var response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "Student/DeleteStudent?id=" + id).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<StudentDTOs>> GetAllStudents()
        {
            try
            {

                var response = await _httpClient.GetAsync("Student/GetAllStudents");
                if (!response.IsSuccessStatusCode) return new List<StudentDTOs>();
                string result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<StudentDTOs>>(result);
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<StudentDTOs> GetStudentById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync("Student/GetStudentById?id="+id);
                if (!response.IsSuccessStatusCode) return new StudentDTOs();
                string result = await response.Content.ReadAsStringAsync();
                var student = JsonConvert.DeserializeObject<StudentDTOs>(result);
                return student;

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void UpdateStudent(StudentDTOs studentDTOs)
        {
            try
            {
                string data = JsonConvert.SerializeObject(studentDTOs);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress+ "Student/UpdateStudent",stringContent).Result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
