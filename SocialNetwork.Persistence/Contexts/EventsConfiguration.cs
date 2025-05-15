using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Persistence.Contexts;

public class EventsConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasData(
        
            new Event { EventId = 1, Name = "The Global Creative", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025,5,1), Author = "UK BRANDS", IntrestedCount = 742, GoingCount = 951 },
            new Event { EventId = 2, Name = "Wedding trend Ideas", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 7, 15), Author = "Catiana", IntrestedCount = 153, GoingCount = 452 },
            new Event { EventId = 3, Name = "About Safety and Flight", Img = "/images/events/img-3.jpg", Date = new DateOnly(2025, 6, 24), Author = "Morleam", IntrestedCount = 651, GoingCount = 753 },
            new Event { EventId = 4, Name = "Perspective is everything", Img = "/images/events/img-4.jpg", Date = new DateOnly(2025, 8, 4), Author = "UK BRANDS", IntrestedCount = 824, GoingCount = 614 },
            new Event { EventId = 5, Name = "Creative Minds Meetup", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025, 3, 1), Author = "Global Hub", IntrestedCount = 345, GoingCount = 567 },
            new Event { EventId = 6, Name = "Tech Innovators Summit", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 5, 1), Author = "TechWorld", IntrestedCount = 234, GoingCount = 456 },
            new Event { EventId = 7, Name = "Art Gallery Opening", Img = "/images/events/img-3.jpg", Date = new DateOnly(2025, 5, 11), Author = "ArtLovers", IntrestedCount = 456, GoingCount = 678 },
            new Event { EventId = 8, Name = "Music Festival Night", Img = "/images/events/img-4.jpg", Date = new DateOnly(2025, 5, 3), Author = "MelodyMakers", IntrestedCount = 567, GoingCount = 789 },
            new Event { EventId = 9, Name = "Startup Pitch Day", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025, 5, 21), Author = "Entrepreneurs", IntrestedCount = 678, GoingCount = 890 },
            new Event { EventId = 10, Name = "Photography Workshop", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 5, 4), Author = "LensCrafters", IntrestedCount = 789, GoingCount = 901 },
            new Event { EventId = 11, Name = "Foodies Gathering", Img = "/images/events/img-3.jpg", Date = new DateOnly(2025, 5, 22), Author = "FoodFanatics", IntrestedCount = 890, GoingCount = 101 },
            new Event { EventId = 12, Name = "Book Club Meeting", Img = "/images/events/img-4.jpg", Date = new DateOnly(2025, 6, 12), Author = "ReadersUnite", IntrestedCount = 901, GoingCount = 112 },
            new Event { EventId = 13, Name = "Fitness Bootcamp", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025, 2, 4), Author = "FitLife", IntrestedCount = 101, GoingCount = 223 },
            new Event { EventId = 14, Name = "Yoga and Meditation", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 5, 7), Author = "ZenMasters", IntrestedCount = 223, GoingCount = 334 },
            new Event { EventId = 15, Name = "Coding Hackathon", Img = "/images/events/img-3.jpg", Date = new DateOnly(2025, 5, 13), Author = "CodeNinjas", IntrestedCount = 334, GoingCount = 445 },
            new Event { EventId = 16, Name = "Gaming Tournament", Img = "/images/events/img-4.jpg", Date = new DateOnly(2025, 5, 5), Author = "GameOn", IntrestedCount = 445, GoingCount = 556 },
            new Event { EventId = 17, Name = "Film Screening Night", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025, 4, 1), Author = "Cinephiles", IntrestedCount = 556, GoingCount = 667 },
            new Event { EventId = 18, Name = "Dance Workshop", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 5, 1), Author = "DanceLovers", IntrestedCount = 667, GoingCount = 778 },
            new Event { EventId = 19, Name = "Fashion Show Extravaganza", Img = "/images/events/img-3.jpg", Date = new DateOnly(2025, 5, 1), Author = "StyleIcons", IntrestedCount = 778, GoingCount = 889 },
            new Event { EventId = 20, Name = "Networking Mixer", Img = "/images/events/img-4.jpg", Date = new DateOnly(2025, 5, 2), Author = "Connectors", IntrestedCount = 889, GoingCount = 990 },
            new Event { EventId = 21, Name = "Science Fair", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025, 4, 30), Author = "ScienceGeeks", IntrestedCount = 990, GoingCount = 111 },
            new Event { EventId = 22, Name = "Charity Gala Dinner", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 4, 30), Author = "KindHearts", IntrestedCount = 111, GoingCount = 222 },
            new Event { EventId = 23, Name = "Pet Adoption Day", Img = "/images/events/img-3.jpg", Date = new DateOnly(2025, 4, 30), Author = "PawsAndClaws", IntrestedCount = 222, GoingCount = 333 },
            new Event { EventId = 24, Name = "Outdoor Adventure", Img = "/images/events/img-4.jpg", Date = new DateOnly(2025, 4, 30), Author = "NatureExplorers", IntrestedCount = 333, GoingCount = 444 },
            new Event { EventId = 25, Name = "Cooking Masterclass", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025, 5, 2), Author = "KitchenExperts", IntrestedCount = 444, GoingCount = 555 },
            new Event { EventId = 26, Name = "DIY Craft Workshop", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 5, 12), Author = "CraftyHands", IntrestedCount = 555, GoingCount = 666 },
            new Event { EventId = 27, Name = "Language Exchange Meetup", Img = "/images/events/img-3.jpg", Date = new DateOnly(2025, 5, 10), Author = "Polyglots", IntrestedCount = 666, GoingCount = 777 },
            new Event { EventId = 28, Name = "Board Games Night", Img = "/images/events/img-4.jpg", Date = new DateOnly(2025, 5, 1), Author = "GameNight", IntrestedCount = 777, GoingCount = 888 },
            new Event { EventId = 29, Name = "Virtual Reality Experience", Img = "/images/events/img-1.jpg", Date = new DateOnly(2025, 5, 14), Author = "VRWorld", IntrestedCount = 888, GoingCount = 999 },
            new Event { EventId = 30, Name = "Comedy Night Live", Img = "/images/events/img-2.jpg", Date = new DateOnly(2025, 5, 13), Author = "LaughOutLoud", IntrestedCount = 999, GoingCount = 1010 }
        );
    }
}