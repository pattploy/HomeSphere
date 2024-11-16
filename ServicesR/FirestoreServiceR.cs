using System;
using Google.Cloud.Firestore;
using _1111.ModelsR;

namespace _1111.ServicesR
{
    public class FirestoreServiceR
    {
        private FirestoreDb db;
        public string StatusMessage;

        public FirestoreServiceR()
        {
            this.SetupFireStoreR();
        }
        private async Task SetupFireStoreR()
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

        public async Task<List<UserModelR>> GetAllUserR()
        {
            try
            {
                await SetupFireStoreR();
                var data = await db.Collection("Repair").GetSnapshotAsync();
                var userRs = data.Documents.Select(doc =>
                {
                    var userR = new UserModelR();
                    userR.RoomNo = doc.GetValue<string>("RoomNo");
                    userR.Things = doc.GetValue<string>("Things");
                    userR.Description = doc.GetValue<string>("Description");
                    return userR;
                }).ToList();
                return userRs;
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public async Task InsertUserR(UserModelR userR)
        {
            try
            {
                await SetupFireStoreR();
                var userRData = new Dictionary<string, object>
            {
                { "RoomNo", userR.RoomNo },
                { "Things", userR.Things },
                { "Description", userR.Description }
                // Add more fields as needed
            };

                await db.Collection("Repair").AddAsync(userRData);
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public async Task UpdateUserR(UserModelR userR)
        {
            try
            {
                await SetupFireStoreR();

                // Manually create a dictionary for the updated data
                var userRData = new Dictionary<string, object>
                {
                { "RoomNo", userR.RoomNo },
                { "Things", userR.Things },
                { "Description", userR.Description }
                // Add more fields as needed
            };

                // Reference the document by its Id and update it
                var docRef = db.Collection("Repair").Document(userR.RoomNo);
                await docRef.SetAsync(userRData, SetOptions.Overwrite);

                StatusMessage = "Sample successfully updated!";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }


    }
}
