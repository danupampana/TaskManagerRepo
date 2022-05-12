using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Handlers;
using TaskManager.Application.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.NUnit.ApiTests.Queries
{
    using static Testing;
    public class GetTasksTests
    {
        [Test]
        public async Task GetAllTasks_ShouldResturnAllTasks()
        {
            //Arrange
            await AddAsync(new TASK_DATA
            {
                TASK_NAME = "Task Job30",
                TASK_DESCRIPTION = "Task Job 30",
                TASK_DUEDATE = Convert.ToDateTime("05/20/2022"),
                TASK_STARTDATE = Convert.ToDateTime("05/16/2022"),
                TASK_ENDDATE = Convert.ToDateTime("05/20/2022"),
                TASK_PRIORITY = "High",
                TASK_STATUS = "New"
            });
            await AddAsync(new TASK_DATA
            {
                TASK_NAME = "Task Job31",
                TASK_DESCRIPTION = "Task Job 31",
                TASK_DUEDATE = Convert.ToDateTime("05/20/2022"),
                TASK_STARTDATE = Convert.ToDateTime("05/16/2022"),
                TASK_ENDDATE = Convert.ToDateTime("05/20/2022"),
                TASK_PRIORITY = "High",
                TASK_STATUS = "New"
            });
            await AddAsync(new TASK_DATA
            {
                TASK_NAME = "Task Job32",
                TASK_DESCRIPTION = "Task Job 32",
                TASK_DUEDATE = Convert.ToDateTime("05/20/2022"),
                TASK_STARTDATE = Convert.ToDateTime("05/16/2022"),
                TASK_ENDDATE = Convert.ToDateTime("05/20/2022"),
                TASK_PRIORITY = "High",
                TASK_STATUS = "New"
            });

            //Act
            using var scope = Testing.scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            var result = await mediator.Send(new GetAllTasks.Query());

            //Assert
            result.tasks.Should().NotBeNull();
            result.tasks.Should().HaveCountGreaterThan(1);
        }
    }
}
