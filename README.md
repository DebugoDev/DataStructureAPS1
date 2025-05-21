# 🏥 Hospital Triage System

## 🇺🇸 English

This project simulates a hospital triage system, developed in C# using object-oriented programming and data structures such as `Queue`, `PriorityQueue`, and `Dictionary`.

### ✨ Features
- CPF registration with format/validation.
- Triage queue (first-come, first-served).
- Clinical care queue (sorted by urgency).
- Patient classification based on blood pressure and body temperature.
- Management and display of triaged patients.

### 🏗️ Project Structure
- **BloodPressure**: Struct to represent blood pressure.
- **Patient**: Represents a patient with CPF, full name, and triage history.
- **Triage**: Records a triage with vital data and priority.
- **Hospital**: Manages patients, queues, and triages.
- **ETriagePriority**: Enum that defines triage priorities (RED, YELLOW, GREEN).

### 🚀 Running
To run the project:
```bash
dotnet run
```

## 🇧🇷 Português

Este projeto simula o funcionamento de um sistema de triagem hospitalar, desenvolvido em C# utilizando conceitos de orientação a objetos e estruturas de dados como `Queue`, `PriorityQueue` e `Dictionary`.

### ✨ Funcionalidades
- Registro e formatação/validação de CPF.
- Fila de triagem (ordem de chegada).
- Fila de atendimento clínico (por prioridade de gravidade).
- Classificação de pacientes com base na pressão arterial e temperatura corporal.
- Visualização e gerenciamento de pacientes triados.

### 🏗️ Estrutura do Projeto
- **BloodPressure**: Struct para representar a pressão arterial.
- **Patient**: Representa um paciente, com CPF, nome completo e histórico de triagens.
- **Triage**: Registra uma triagem com dados vitais e prioridade.
- **Hospital**: Gerencia pacientes, filas e triagens.
- **ETriagePriority**: Enum que define as prioridades de triagem (VERMELHO, AMARELO, VERDE).

### 🚀 Execução
Para executar o projeto:
```bash
dotnet run
```