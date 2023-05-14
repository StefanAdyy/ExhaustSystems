using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Dtos;
using Core.Dtos;
using DataLayer.Entities;
using System.Security.Cryptography;

namespace Core.Services
{
    public class PartService
    {
        private readonly UnitOfWork unitOfWork;

        public PartService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddPart(AddPartDto part)
        {
            try
            {
                if (part == null)
                {
                    return;
                }

                var newPart = new Part
                {
                    Name = part.Name,
                    Description = part.Description,
                    Code = part.Code
                };

                unitOfWork.Parts.Insert(newPart);
                unitOfWork.SaveChanges();
            }
            catch(Exception exception)
            {
                Console.WriteLine("An error occurred while adding the part: " + exception.Message);
                throw new Exception("An error occurred while adding the part.", exception);
            }
        }

        public List<Part> GetAll()
        {
            try
            {
                var results = unitOfWork.Parts.GetAll();

                return results;
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred while retrieving  the part: " + exception.Message);
                throw new Exception("An error occurred while retrieving  the part.", exception);
            }
        }

        public Part GetById(int partId)
        {
            try
            {
                var part = unitOfWork.Parts.GetById(partId);

                return part;
            }
            catch(Exception exception)
            {
                Console.WriteLine("An error occurred while retrieving the parth with ID: " + partId + ": " + exception.Message);
                throw new Exception("An error occurred while retrieving the part.", exception);
            }
        }

        public bool EditPartDetails(EditPartDto editPartDto)
        {
            try
            {
                if (editPartDto == null)
                {
                    return false;
                }

                var result = unitOfWork.Parts.GetById(editPartDto.Id);
                if (result == null)
                {
                    return false;
                }

                result.Description = editPartDto.Description;
                result.Name = editPartDto.Name;
                result.Code = editPartDto.Code;

                unitOfWork.Parts.Update(result);
                unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred while editing the part: " + exception.Message);
                throw new Exception("An error occurred while editing the part.", exception);
            }
        }

        public bool DeletePart(int partId)
        {
            try
            {

                var result = unitOfWork.Parts.GetById(partId);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.Parts.Remove(result);
                return true;
            }
            catch(Exception exception)
            {
                Console.WriteLine("An error occurred while deleting the part: " + exception.Message);
                throw new Exception("An error occurred while deleting the dog.", exception);
            }
        }
    }
}
