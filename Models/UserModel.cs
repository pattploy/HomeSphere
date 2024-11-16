using Google.Cloud.Firestore;
using System;

namespace _1111.Models
{ 
    public class UserModel
    {
        [FirestoreProperty]
        public int RoomNo { get; set; }

        [FirestoreProperty]
        public int Date { get; set; }


        [FirestoreProperty]
        public int ParcelNo { get; set; }
    } 
}

