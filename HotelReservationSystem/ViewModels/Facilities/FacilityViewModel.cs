﻿namespace HotelReservationSystem.ViewModels.Facilities
{
    public class FacilityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
