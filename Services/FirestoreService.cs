using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1111.Models;


namespace _1111.Services
{
    public class FirestoreService
    {
        private FirestoreDb db;
        public string StatusMessage;

        public FirestoreService()
        {
            this.SetupFireStore();
        }
        private async Task SetupFireStore()
        {
            if (db == null)
            {
                var stream = await FileSystem.OpenAppPackageFileAsync("homesphere-adaf3-firebase-adminsdk-rs81k-b8342b6325.json");
                var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();
                db = new FirestoreDbBuilder
                {
                    ProjectId = "homesphere-adaf3",

                    JsonCredentials = contents
                }.Build();
            }
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            try
            {
                await SetupFireStore();
                var data = await db.Collection("Parcel").GetSnapshotAsync();
                var users = data.Documents.Select(doc =>
                {
                    var user = new UserModel();
                    user.RoomNo = doc.GetValue<int>("RoomNo");
                    user.Date = doc.GetValue<int>("Date");
                    user.ParcelNo = doc.GetValue<int>("ParcelNo");
                    return user;
                }).ToList();
                return users;
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        
    }
}
