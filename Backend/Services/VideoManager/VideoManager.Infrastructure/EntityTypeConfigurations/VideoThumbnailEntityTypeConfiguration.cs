﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManager.Domain.Models;

namespace VideoManager.Infrastructure.EntityTypeConfigurations;

public class VideoThumbnailEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<VideoThumbnail> builder)
    {
        builder.Property<int>("Id");
        builder.HasKey("Id");

        builder.Property(x => x.ImageFileId).IsRequired();

        builder.Property(x => x.Label).IsRequired();

        builder.Property(x => x.Width).IsRequired();

        builder.Property(x => x.Height).IsRequired();

        builder.Property(x => x.Url).IsRequired();
    }
}

