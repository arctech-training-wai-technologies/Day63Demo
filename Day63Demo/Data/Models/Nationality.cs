using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Day63Demo.Data.Models;

public class Nationality
{
    public int Id { get; set; }

    [Unicode(false)]
    [StringLength(50)]
    public string Text { get; set; } = null!;


    [Unicode(false)]
    [StringLength(50)]
    public string Continent { get; set; } = null!;

    public int CountryPopulation { get; set; }
}