# 🏃‍♂️ StraviaTEC — Sports Activity Platform

## 📘 Overview

This repository contains the complete solution to StraviaTEC, a sports activity management platform developed for the course CE3101 – Bases de Datos at Instituto Tecnológico de Costa Rica.

StraviaTEC is a social and administrative system for athletes and event organizers. It supports the registration, tracking, and visualization of physical activities like running, cycling, and hiking, while offering event management tools, mobile support, and robust data handling via SQL Server and MongoDB.

---

## 🎯 Core Features

- ✅ **User account creation** with personal and demographic information
- 📍 **Activity registration** (type, duration, route, GPS data, etc.)
- 🔎 **Search and follow other athletes**
- 📈 **Activity feeds** showing summary data and maps from friends
- 🗣️ **Comment system** for posts (stored in MongoDB)
- 🏅 **Join events and challenges** with progress tracking and position boards
- 💳 **Event payment validation** via receipt upload (for races)
- 📊 **Reports** for participant lists and ranked results
- 🏃 **Organizers interface** to manage races, challenges, groups, and sponsors
- 📱 **Mobile App** to record activities with live stats and local SQLite storage

---

## 💾 Technologies

- **Frontend**: Angular, HTML5, CSS, Bootstrap
- **Backend**: C# Web API with SQL Server and MongoDB
- **Databases**:
  - SQL Server for structured data and business logic (stored procedures, views, triggers)
  - MongoDB for unstructured comments and interactions
  - SQLite for offline data storage on the mobile app
- **Deployment**: Azure or AWS cloud environment

---

## 📌 Notes

This repository includes:
- Web and mobile app source code
- Stored procedures, triggers, and views
- API endpoints for both SQL Server and MongoDB
- Reports, documentation, and installation guide

StraviaTEC is a comprehensive academic project that reflects the integration of software engineering, database design, and teamwork applied to a real-world use case in the sports community.
