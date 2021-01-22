using System;
using System.Collections.Generic;
using AutoMapper;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Services.Api.Controllers;
using Eventos.IO.Services.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Eventos.IO.Tests.API.Unit_Tests
{
    public class EventosControllerTests
    {
        public EventosController eventosController { get; set; }
        public EventoViewModel eventoViewModel { get; set; }
        public RegistrarEventoCommand eventoCommand { get; set; }
        public Mock<IMapper> mockMapper { get; set; }
        public Mock<IMediatorHandler> mockMediator { get; set; }
        public Mock<DomainNotificationHandler> mockNotification { get; set; }

        public EventosControllerTests()
        {
            mockMapper = new Mock<IMapper>();
            mockMediator = new Mock<IMediatorHandler>();
            mockNotification = new Mock<DomainNotificationHandler>();

            var mockUser = new Mock<IUser>();
            var mockRepository = new Mock<IEventoRepository>();

            eventoViewModel = new EventoViewModel();

            eventoCommand = new RegistrarEventoCommand("Teste", "", "", DateTime.Now, DateTime.Now.AddDays(1), true,
                0, true, "Teste", Guid.NewGuid(), Guid.NewGuid(),
                new IncluirEnderecoEventoCommand(Guid.NewGuid(), "", "", "", "", "", "", "", Guid.NewGuid()));

            eventosController = new EventosController(
                mockNotification.Object,
                mockUser.Object,
                mockRepository.Object,
                mockMapper.Object,
                mockMediator.Object);
        }


        // Registrar um evento com sucesso
        // Registrar um evento com falha na viewmodel
        // Registrar um evento com falha na validacao de dominio

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Registrar evento com sucesso")]
        [Trait("Category","Testes Eventos Controller")]
        public void EventosController_RegistrarEvento_RetornarComSucesso()
        {
            // Arrange
            mockMapper.Setup(m => m.Map<RegistrarEventoCommand>(eventoViewModel)).Returns(eventoCommand);

            // Act
            var result = eventosController.Post(eventoViewModel);

            // Assert
            mockMediator.Verify(m => m.EnviarComando(eventoCommand), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact(DisplayName = "Registrar evento com erro de ModelState")]
        [Trait("Category", "Testes Eventos Controller")]
        public void EventosController_RegistrarEvento_RetornarComErrosDeModelState()
        {
            // Arrange
            mockMapper.Setup(m => m.Map<RegistrarEventoCommand>(eventoViewModel)).Returns(eventoCommand);
            var notificationList = new List<DomainNotification>
            {
                new DomainNotification("Erro","Model Error")
            };

            mockNotification.Setup(c => c.GetNotifications()).Returns(notificationList);
            mockNotification.Setup(c => c.HasNotifications()).Returns(true);

            eventosController.ModelState.AddModelError("Erro", "Model Error");

            // Act
            var result = eventosController.Post(eventoViewModel);

            // Assert
            mockMapper.Verify(m => m.Map<RegistrarEventoCommand>(eventoViewModel), Times.Never);
            mockMediator.Verify(m => m.EnviarComando(eventoCommand), Times.Never);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact(DisplayName = "Registrar evento com erro de Dominio")]
        [Trait("Category", "Testes Eventos Controller")]
        public void EventosController_RegistrarEvento_RetornarComErrosDeDominio()
        {
            // Arrange
            mockMapper.Setup(m => m.Map<RegistrarEventoCommand>(eventoViewModel)).Returns(eventoCommand);
            var notificationList = new List<DomainNotification>
            {
                new DomainNotification("Erro","Domain Error")
            };

            mockNotification.Setup(c => c.GetNotifications()).Returns(notificationList);
            mockNotification.Setup(c => c.HasNotifications()).Returns(true);

            // Act
            var result = eventosController.Post(eventoViewModel);

            // Assert
            mockMediator.Verify(m => m.EnviarComando(eventoCommand), Times.Once);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}