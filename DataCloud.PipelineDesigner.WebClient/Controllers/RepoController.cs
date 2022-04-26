﻿using DataCloud.PipelineDesigner.Repositories.Models;
using DataCloud.PipelineDesigner.Services.Interfaces;
using DataCloud.PipelineDesigner.WebClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCloud.PipelineDesigner.WebClient.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        Services.Interfaces.IUserService userService;
        Services.Interfaces.IPublicRepoService pRepoService;
        public RepoController(IUserService uService, IPublicRepoService prService)
        {
            userService = uService;
            pRepoService = prService;
        }

        [HttpGet("s")]
        public async Task<ApiResult<List<PublicRepo>>> SearchRepo([FromQuery] string query)
        {
            try
            {
                List<PublicRepo> prs = await pRepoService.Search(query);
                return ApiHelper.CreateSuccessResult(prs);
            }
            catch (Exception e)
            {
                return ApiHelper.CreateFailedResult<List<PublicRepo>>(e.Message);
            }
        }

        [HttpGet]
        public async Task<ApiResult<Template>> ImportRepo([FromQuery] string user, [FromQuery] string workflowName)
        {
            try
            {
                Template prs = await pRepoService.GetPublicRepo(user, workflowName);
                return ApiHelper.CreateSuccessResult(prs);
            }
            catch (Exception e)
            {
                return ApiHelper.CreateFailedResult<Template>(e.Message);
            }
        }

        [HttpGet("{user}")]
        public async Task<ApiResult<List<Template>>> GetAvailableRepo(String user)
        {
            try
            {
                User userDB = await userService.GetRepoAsync(user);
                return ApiHelper.CreateSuccessResult(userDB.Templates);
            }
            catch (Exception e)
            {
                return ApiHelper.CreateFailedResult<List<Template>>(e.Message);
            }
        }

        [HttpPost("{user}")]
        public async Task<ApiResult<Template>> AddOrUpdateRepoAsync([FromBody] Template template, string user)
        {
            try
            {
                var result = await userService.UpdateRepoAsync(template, user);


                // Probably a better way to do nested upsert
                if(result.ModifiedCount < 1)
                {
                    await userService.AddRepoAsync(template, user);
                }

                if (template.Public)
                {
                    await pRepoService.AddRepo(user, template.Name);
                }
                else
                {
                    await pRepoService.RemoveRepo(user, template.Name);
                }

                return ApiHelper.CreateSuccessResult(template);
            }
            catch (Exception e)
            {
                return ApiHelper.CreateFailedResult<Template>(e.Message);
            }
        }

        [HttpDelete("{user}/{id}")]
        public async Task<ApiResult<bool>> DeleteTemplate(String user, String id)
        {
            try
            {

                await userService.DeleteTemplate(user, id);

                return ApiHelper.CreateSuccessResult(true);
            }
            catch (Exception e)
            {
                return ApiHelper.CreateFailedResult<bool>(e.Message);
            }
        }
    }
}