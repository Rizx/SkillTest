using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace SkillTest.WebApplication
{
    public static class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string _endpointUrl = @"http://localhost:5001/SkillTest";

        public static async Task<List<DataDto>> GetData(long id)
        {
            Result<List<DataDto>> result = await SendRequest<List<DataDto>>($"?id={id}", HttpMethod.Get).ConfigureAwait(false);
            return result.Value;
        }

        public static async Task<List<LokasiDto>> GetLokasiList()
        {
            Result<List<LokasiDto>> result = await SendRequest<List<LokasiDto>>($"alokasi", HttpMethod.Get).ConfigureAwait(false);
            return result.Value;
        }

        public static async Task<List<DataDto>> GetDataList()
        {
            Result<List<DataDto>> result = await SendRequest<List<DataDto>>($"data", HttpMethod.Get).ConfigureAwait(false);
            return result.Value;
        }

        public static async Task<List<GroupByLokasiDto>> GetGroupByLokasi()
        {
            Result<List<GroupByLokasiDto>> result = await SendRequest<List<GroupByLokasiDto>>($"groupLokasi", HttpMethod.Get).ConfigureAwait(false);
            return result.Value;
        }

        public static async Task<Result> CreateData(NewDataDto dto)
        {
            Result result = await SendRequest<string>("/", HttpMethod.Post, dto).ConfigureAwait(false);
            return result;
        }

        public static async Task<Result> DeleteData(long id)
        {
            Result result = await SendRequest<string>("/" + id, HttpMethod.Delete).ConfigureAwait(false);
            return result;
        }

        public static async Task<Result> EditData(EditDataDto dto)
        {
            Result result = await SendRequest<string>("editData/" + dto.Id, HttpMethod.Put, dto).ConfigureAwait(false);
            return result;
        }

        public static async Task<Result> Enroll(EditJudulDto dto)
        {
            Result result = await SendRequest<string>($"editJudul/{dto.Id}", HttpMethod.Post, dto).ConfigureAwait(false);
            return result;
        }

        private static async Task<Result<T>> SendRequest<T>(string url, HttpMethod method, object content = null)
             where T : class
        {
            var request = new HttpRequestMessage(method, $"{_endpointUrl}/{url}");
            if (content != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage message = await _client.SendAsync(request).ConfigureAwait(false);
            string response = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            var envelope = JsonConvert.DeserializeObject<Envelope<T>>(response);

            if (message.StatusCode == HttpStatusCode.InternalServerError)
                throw new Exception(envelope.ErrorMessage);

            if (!message.IsSuccessStatusCode)
                return Result.Fail<T>(envelope.ErrorMessage);

            T result = envelope.Result;

            if (result == null && typeof(T) == typeof(string))
            {
                result = string.Empty as T;
            }

            return Result.Ok(result);
        }
    }
}
