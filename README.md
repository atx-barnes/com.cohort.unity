# Cohort: Unity Conversable-AI Agents

A Unity package that enables developers to quickly implement and develop LLM-based AI agents inside their Unity experiences.

## Overview

Cohort provides a framework for creating conversational AI agents in Unity using Language Learning Models (LLMs). The framework is designed to be flexible, allowing for different LLM providers and agent configurations.

## Features

- Create conversational AI agents in Unity
- Support for text and multimodal content
- Configurable agent definitions using ScriptableObjects
- Extensible architecture for different LLM providers
- Memory management for agent conversations
- Event-based response handling

## Installation

Add this package to your Unity project via the Package Manager:

```
https://github.com/atx-barnes/com.cohort.unity.git
```

## Requirements

- Unity 2020.3 or newer
- OpenAI API key for the sample implementation

## Quick Start

1. Import the package
2. Import the Basic Agent Orchestration sample from the Package Manager
3. Set up your OpenAI API key in `~/.openai` directory
4. Open the AgentOrchestration scene
5. Run the scene to see a basic agent interaction

## Basic Usage

```csharp
// Create an agent using the factory
BasicConversableAgent agent = AgentFactory.Generate<BasicConversableAgent>(model: "GPT-4o", parent: transform);

// Send a message and get a response
ConversableResponse<Text> response = await agent.Execute(new ConversableRequest<Text>(
    IRole.Type.User, 
    new Text { Message = "Hello World" }
));

// Process the response
Debug.Log(response.Content.Message);
```

## Architecture

### Core Components

- **IConversableAgent**: Interface for conversational agents
- **BaseConversableAgent**: Abstract base class for all conversable agents
- **ConversableAgent<T,U>**: Generic implementation of a conversable agent
- **BasicConversableAgent**: Simplest implementation using text content
- **ConversableAgentDefinition**: ScriptableObject for configuring agents
- **ILanguageModel**: Interface for language model implementations
- **ModelFactory**: Creates language model instances

### Content Types

- **IContent**: Base interface for content
- **Text**: Simple text content
- **MultiModal**: Content with both text and images

## Sample: Basic Agent Orchestration

The package includes a sample demonstrating how to:

- Set up an agent prefab and definition
- Create a model factory for OpenAI integration
- Instantiate and communicate with an agent
- Handle responses from the agent

## Extending the Framework

### Creating a Custom Agent

1. Create a new class that extends `ConversableAgent<T,U>` or `BaseConversableAgent`
2. Create a ScriptableObject definition for your agent
3. Create a prefab with your agent component

### Adding a New LLM Provider

1. Create a new class implementing `ICompletionEndpoint`
2. Extend `ModelFactory` to support your provider
3. Map the provider's role types to the framework's role types
