﻿namespace TraversalReservationProject.CQRS.Commands.DestinationCommands
{
    public class AddDestinationCommand
    {
        public string City { get; set; }       
        public int Capacity { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; } 
        public bool Status { get; set; }
    }
}
