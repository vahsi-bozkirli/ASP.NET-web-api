using Business.Abstracts;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        // Business Rules
        // Mapping --> AutoMapper
        Brand brand = new();
        brand.Name = createBrandRequest.Name;
        brand.CreatedTime = DateTime.Now;

        _brandDal.Add(brand);

        // Mapping
        CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
        createdBrandResponse.Name = createBrandRequest.Name;
        createdBrandResponse.Id = 1;
        createdBrandResponse.CreatedDate = brand.CreatedTime;

        return createdBrandResponse;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        List<Brand> brands = _brandDal.GetAll();
        List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();

        foreach(var brand in brands)
        {
            GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
            getAllBrandResponse.Name = brand.Name;
            getAllBrandResponse.Id = brand.Id;
            getAllBrandResponse.CreatedDate = brand.CreatedTime;

            getAllBrandResponses.Add(getAllBrandResponse);
        }

        return getAllBrandResponses;
    }
}
