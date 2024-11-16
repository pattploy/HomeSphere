using Google.Cloud.Firestore;
using System;


namespace _1111.ModelsR
{
    public class UserModelR
    {
        [FirestoreProperty]
        public string RoomNo { get; set; }


        [FirestoreProperty]
        public string Things { get; set; }


        [FirestoreProperty]
        public string Description { get; set; }
    }
}
