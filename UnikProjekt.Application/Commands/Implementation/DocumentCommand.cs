using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Commands.Implementation
{
    public class DocumentCommand : IDocumentCommand
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        public DocumentCommand(IDocumentRepository documentRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _documentRepository = documentRepository;
            _uow = unitOfWork;
            _userRepository = userRepository;
        }
        Guid IDocumentCommand.CreateDocument(CreateDocumentDto createDocumentDto)
        {
            try
            {
                //byte[] pdfInBytes = System.IO.File.ReadAllBytes(filePath);

                _uow.BeginTransaction();

                var user = _userRepository.GetUser(createDocumentDto.UserId);

                var document = Document.Create(createDocumentDto.DocumentContent,
                                               createDocumentDto.DocumentTitle,
                                               user,
                                               createDocumentDto.DateModified);

                _documentRepository.AddDocument(document);

                _uow.Commit();

                return document.Id;
            }

            catch (Exception e)
            {
                try
                {
                    _uow.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", e);
                }
                throw;
            }
        }
    }
}
