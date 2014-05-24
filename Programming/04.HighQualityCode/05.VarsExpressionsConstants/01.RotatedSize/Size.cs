//-----------------------------------------------------------------------
// <copyright file="Size.cs" company="Telerik Academy">
//     Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <summary>Contains the Size class.</summary>
//-----------------------------------------------------------------------

/// <summary>
/// Represents a pair of doubles, which specify a Height and Width.
/// </summary>
public class Size
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Size"/> class.
    /// </summary>
    /// <param name="width">The width component of the new <see cref="Size"/>.</param>
    /// <param name="height">The height component of the new <see cref="Size"/>.</param>
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    /// <summary>
    /// Gets or sets the width component of the <see cref="Size"/>.
    /// </summary>
    /// <value>The width component of the <see cref="Size"/>.</value>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets the height component of the <see cref="Size"/>.
    /// </summary>
    /// <value>The height component of the <see cref="Size"/>.</value>
    public double Height { get; set; }

    /// <summary>
    /// Returns a string containing the width and height component.
    /// </summary>
    /// <returns>A string containing the width and height component.</returns>
    public override string ToString()
    {
        return string.Format("width: {0:F2}, height {1:F2}", this.Width, this.Height);
    }
}