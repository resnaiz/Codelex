using System;
using System.Collections.Generic;

namespace VideoStore
{
    class VideoStore
    {
        private List<Video> newInv = new List<Video>();

        public VideoStore(string title, int rating) { }  
        public void AddVideo(string title)
        {
            newInv.Add(new Video(title));
        }
        
        public void Checkout(string title)
        {
            Video newVideo = newInv.Find(i => i.Title == title && i.Available());

            if(newVideo != null)
            {
                newVideo.BeingCheckedOut();
            }
            else
            {
                Console.WriteLine($"Sorry, but {title} is not available.");
            }
        }

        public void ReturnVideo(string title)
        {
            Video otherVideo = newInv.Find(i => i.Title == title && i.Available());

            if(otherVideo != null)
            {
                otherVideo.BeingReturned();
            }
            else
            {
                Console.WriteLine($"Sorry, but {title} - not checked out.");
            }
        }

        public void TakeUsersRating(int rating, string title)
        {
            Video anotherVideo = newInv.Find(i => i.Title == title);

            if(anotherVideo != null)
            {
                anotherVideo.ReceivingRating(rating);
            }
        }

        public void ListInventory()
        {
            Console.WriteLine("Inventory view: ");

            foreach(var oneVideo in newInv)
            {
                Console.WriteLine(oneVideo.ToString());
            }
        }
    }
}