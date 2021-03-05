﻿using System.Collections.Generic;
using System.Linq;
using OpenA3XX.Core.Forms;
using OpenA3XX.Core.Repositories;

namespace OpenA3XX.Core.Services
{
    public class FormsService : IFormService
    {
        private readonly ISystemConfigurationRepository _systemConfigurationRepository;
        private readonly ISimulatorEventService _simulatorEventService;

        public FormsService(ISystemConfigurationRepository systemConfigurationRepository,
            ISimulatorEventService simulatorEventService)
        {
            _systemConfigurationRepository = systemConfigurationRepository;
            _simulatorEventService = simulatorEventService;
        }

        public IList<FieldConfig> GetSimLinkFormForHardwareInputSelectorId(int hardwareInputSelectorId)
        {
            var simulatorEvents = _simulatorEventService.GetAllSimulatorEvents();

            var simLinkForm = new List<FieldConfig>
            {
                new()
                {
                    FieldType = FieldType.Select,
                    Options = new List<KeyValuePair<string, string>>()
                    {
                        new ("1","SimConnect: Direct"),
                        new ("2", "SimConnect: OpenA3XX WASM Gauge"),
                        new ("3", "FSUIPC"),
                        new ("4", "Websockets")
                    },
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "Integration Type is Required"
                        }
                    },
                    Label = "Integration Type",
                    Name = "inputIntegrationType",
                    Hint = "Select type of integration to the Simulator Software"
                },
                new()
                {
                    FieldType = FieldType.Select,
                    Options = simulatorEvents.Select(c => new KeyValuePair<string,string>(c.Id.ToString(), $"{c.FriendlyName} - {c.EventCode}")),
                    Label = "Simulator Event",
                    Name = "simulatorEvent",
                    Hint = "Select event to trigger to the Simulator Software",
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "Simulator Event is Required"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Button,
                    Label = "Apply"
                }
            };

            return simLinkForm;
        }

        public IList<FieldConfig> GetSettingsFormFields()
        {
            var configuration = _systemConfigurationRepository.GetAllConfiguration();

            var settingsForm = new List<FieldConfig>
            {
                new()
                {
                    FieldType = FieldType.Heading,
                    Label = "RabbitMQ Configuration"
                },
                new()
                {
                    FieldType = FieldType.Input,
                    InputFieldType = InputFieldType.Text,
                    Label = "RabbitMQ Host Address",
                    Name = "opena3xx-amqp-host",
                    Hint = "RabbitMQ Host Address is the IP Address where RabbitMQ is running.",
                    Value = configuration.First(c => c.Key == "opena3xx-amqp-host").Value,
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "RabbitMQ Host is Required"
                        },
                        new()
                        {
                            FieldValidationType = FieldValidationType.Pattern,
                            Pattern =
                                "(localhost|\\b(?:(?:25[0-5]|2[0-4]\\d|[01]?\\d\\d?)\\.){3}(?:25[0-5]|2[0-4]\\d|[01]?\\d\\d?)(?::\\d{0,4})?\\b)",
                            Message = "Accept only IPv4 Address or localhost"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Input,
                    InputFieldType = InputFieldType.Text,
                    Label = "RabbitMQ Host Port",
                    Name = "opena3xx-amqp-port",
                    Hint = "RabbitMQ Port on which it is running (amqp protocol)",
                    Value = configuration.First(c => c.Key == "opena3xx-amqp-port").Value,
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "RabbitMQ Port is Required"
                        },
                        new()
                        {
                            FieldValidationType = FieldValidationType.Pattern,
                            Pattern =
                                "^()([1-9]|[1-5]?[0-9]{2,4}|6[1-4][0-9]{3}|65[1-4][0-9]{2}|655[1-2][0-9]|6553[1-5])$",
                            Message = "RabbitMQ Port is required: 1-65535"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Input,
                    InputFieldType = InputFieldType.Text,
                    Label = "RabbitMQ Username",
                    Name = "opena3xx-amqp-username",
                    Hint = "RabbitMQ Username used for Authentication",
                    Value = configuration.First(c => c.Key == "opena3xx-amqp-username").Value,
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "RabbitMQ Username is Required"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Input,
                    InputFieldType = InputFieldType.Text,
                    Label = "RabbitMQ Password",
                    Name = "opena3xx-amqp-password",
                    Hint = "RabbitMQ Password used for Authentication",
                    Value = configuration.First(c => c.Key == "opena3xx-amqp-password").Value,
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "RabbitMQ Password is Required"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Input,
                    InputFieldType = InputFieldType.Text,
                    Label = "RabbitMQ Virtual Host",
                    Name = "opena3xx-amqp-vhost",
                    Hint = "RabbitMQ Virtual Host",
                    Value = configuration.First(c => c.Key == "opena3xx-amqp-vhost").Value,
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "RabbitMQ Virtual Host is Required"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Heading,
                    Label = "SEQ Configuration"
                },
                new()
                {
                    FieldType = FieldType.Input,
                    InputFieldType = InputFieldType.Text,
                    Label = "SEQ Host Address",
                    Name = "opena3xx-logging-seq-host",
                    Hint = "SEQ Host Address is the IP Address where SEQ is running.",
                    Value = configuration.First(c => c.Key == "opena3xx-logging-seq-host").Value,
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "SEQ Host is Required"
                        },
                        new()
                        {
                            FieldValidationType = FieldValidationType.Pattern,
                            Pattern =
                                "(localhost|\\b(?:(?:25[0-5]|2[0-4]\\d|[01]?\\d\\d?)\\.){3}(?:25[0-5]|2[0-4]\\d|[01]?\\d\\d?)(?::\\d{0,4})?\\b)",
                            Message = "Accept only IPv4 Address or localhost"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Input,
                    InputFieldType = InputFieldType.Text,
                    Label = "SEQ Host Port",
                    Name = "opena3xx-logging-seq-port",
                    Hint = "SEQ Port on which it is running",
                    Value = configuration.First(c => c.Key == "opena3xx-logging-seq-port").Value,
                    Validations = new List<FieldValidatorConfig>
                    {
                        new()
                        {
                            FieldValidationType = FieldValidationType.Required,
                            Message = "SEQ Port is Required"
                        },
                        new()
                        {
                            FieldValidationType = FieldValidationType.Pattern,
                            Pattern =
                                "^()([1-9]|[1-5]?[0-9]{2,4}|6[1-4][0-9]{3}|65[1-4][0-9]{2}|655[1-2][0-9]|6553[1-5])$",
                            Message = "SEQ Port is required: 1-65535"
                        }
                    }
                },
                new()
                {
                    FieldType = FieldType.Button,
                    Label = "Save All Settings"
                }
            };
            return settingsForm;
        }
    }
}