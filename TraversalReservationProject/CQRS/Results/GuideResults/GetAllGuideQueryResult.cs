﻿namespace TraversalReservationProject.CQRS.Results.GuideResults
{
    public class GetAllGuideQueryResult
    {
        public int GuideId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
