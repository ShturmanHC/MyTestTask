﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestTask.Application.Common
{
	public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
		where TRequest : ICommand<TResponse>
	{
	}

	public interface ICommandHandler<TRequest> : IRequestHandler<TRequest>
		where TRequest : ICommand
	{ 
	}
}
