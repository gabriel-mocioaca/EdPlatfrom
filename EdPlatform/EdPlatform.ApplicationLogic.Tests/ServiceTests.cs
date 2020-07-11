using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace EdPlatform.ApplicationLogic.Tests
{
  [TestClass]
  public class ServiceTests
  {
    [TestMethod]
    public void GetMessagesInClassroom_ThrowsException_WhenClassroomIdIsNull()
    {
      Mock<IMessageRepository> messageRepoMock = new Mock<IMessageRepository>();

      MessageService messageService = new MessageService(messageRepoMock.Object);

      string badClassroomId = null;

      Assert.ThrowsException<Exception>(() =>
      {
        messageService.GetMessagesInClassroom(badClassroomId);
      });
    }
    [TestMethod]
    public void GetClassroomByClassroomId_ThrowsException_WhenClassroomIdIsNull()
    {
      Mock<IClassroomRepository> classroomRepoMock = new Mock<IClassroomRepository>();

      ClassroomService classroomService = new ClassroomService(classroomRepoMock.Object);

      string badClassroomId = null;

      Assert.ThrowsException<Exception>(() =>
      {
        classroomService.GetClassroomByClassroomId(badClassroomId);
      });
    }
    [TestMethod]
    public void AddClassroom_ThrowsException_WhenClassroomNameIsNull()
    {
      Mock<IClassroomRepository> classroomRepoMock = new Mock<IClassroomRepository>();

      ClassroomService classroomService = new ClassroomService(classroomRepoMock.Object);

      string badClassroomName = null;

      Assert.ThrowsException<Exception>(() =>
      {
        classroomService.AddClassroom(null, badClassroomName, "Tim");
      });
    }
    [TestMethod]
    public void AddClassroom_ThrowsException_WhenCreatorNameIsNull()
    {
      Mock<IClassroomRepository> classroomRepoMock = new Mock<IClassroomRepository>();

      ClassroomService classroomService = new ClassroomService(classroomRepoMock.Object);

      string badCreatorName = null;

      Assert.ThrowsException<Exception>(() =>
      {
        classroomService.AddClassroom(null, "This title", badCreatorName);
      });
    }
    [TestMethod]
    public void GetClassrooms_ThrowsException_WhenClassroomIdIsNull()
    {
      Mock<IClassroomRepository> classroomRepoMock = new Mock<IClassroomRepository>();

      ClassroomService classroomService = new ClassroomService(classroomRepoMock.Object);

      string participantId = null;

      Assert.ThrowsException<Exception>(() =>
      {
        classroomService.GetClassrooms(participantId);
      });
    }
  }
}
