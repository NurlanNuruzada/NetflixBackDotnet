﻿using ParkCinema.Application.DTOs.ActorMovieDescription;

namespace ParkCinema.Application.DTOs.MovieDescription;

public class MovieDescriptionUpdateDto
{
    public string FullDesription { get; set; }
    public TimeSpan MovieDuration { get; set; }
    public double Rating { get; set; }
    public DateTime RelaseDate { get; set; }
    public int AgeLimit { get; set; }

    //Relatihons
    public Guid MovieId { get; set; }
    public List<ActorMovieDescriptionUpdateDto>? actorMovieDescriptionsUpdateDto { get; set; }
}
