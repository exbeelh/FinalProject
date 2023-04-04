using FinalProject.Models;

namespace FinalProject.Interfaces;

interface IElementRepository
{
    List<Element> GetElements();
}