Wheel_Game

Mobile game prototype built with Unity. Implements a spin-the-wheel mechanic, reward handling, and event-driven UI updates.

⸻

✨ Features
	
 •	🎡 Roulette System – Bronze, Silver, and Gold wheels with unique rewards

 •	⚡ Event-Driven Architecture – loosely coupled communication with immutable events

 •	🧩 Layered Architecture – clean separation of Domain, Application, Infrastructure, and Presentation

 •	🖼️ UI System – modular popups, zone bar, and controls

 •	🗂️ Scriptable Objects – wheel configurations, item databases, and zone settings

 •	🔄 Factories & Spawners – decoupled object creation and runtime spawning

🗂️ Project Structure


Scripts/
├─ Domain/               # Pure game rules & data models (no Unity dependencies)

│  ├─ WheelItem.cs

│  └─ RouletteData.cs

│

├─ Application/          # Use-cases, orchestration of domain logic

│  ├─ Events/            # Immutable game events

│  │  ├─ AddZoneNumberEvent.cs

│  │  └─ RouletteSpinStoppedEvent.cs

│  └─ Factories/

│     ├─ WheelItemFactory.cs

│     └─ RouletteFactory.cs

│

├─ Infrastructure/       # External systems, messaging, configs

│  ├─ Messaging/

│  │  ├─ EventBus.cs

│  │  └─ GlobalBus.cs

│  └─ Config/

│     ├─ RouletteTypeSO.cs

│     ├─ WheelItemDatabaseSO.cs

│     └─ ZoneLevelConfigSO.cs

│

└─ Presentation/         # MonoBehaviours, UI, Spawners, Animations

├─ Bootstrap/

│  └─ UIBootstrapper.cs

├─ Roulette/

│  ├─ Spawners/

│  │  ├─ RouletteSpawner.cs

│  │  └─ RouletteItemSpawner.cs

│  └─ Views/

│     ├─ RouletteMono.cs

│     ├─ WheelItemMono.cs

│     └─ RoulettePhysicsSpinner.cs

├─ UI/

│  ├─ Popups/

│  │  ├─ CardPopupUIPresenter.cs

│  │  └─ BombPopupUIPresenter.cs

│  ├─ Containers/

│  │  ├─ ItemContainerMono.cs

│  │  └─ ItemSlotUI.cs

│  ├─ Controls/

│  │  ├─ SpinButtonBinder.cs

│  │  ├─ ExitButtonBinder.cs

│  │  └─ GiveUpButtonBinder.cs

│  └─ ZoneBar/

│     ├─ ZoneSlideMono.cs

│     └─ ZoneNumberItem.cs

└─ Common/            # Shared helpers & extensions


📦 Scriptable Objects (Assets/Scriptable)

Scriptable/
├─ Item/        → Item SOs (item_1, item_2, …)
├─ Roulette/    → BronzeRoulette, SilverRoulette, GoldRoulette
└─ Zone/        → ZoneLevelConfigSO asset

⚙️ Architecture Principles
	•	One-way flow: Domain → Application → Infrastructure → Presentation
	•	Dependency Rules:
	•	Presentation depends on Application
	•	Application depends on Domain
	•	Domain is independent (no dependencies)
	•	Unity-specific code (MonoBehaviour, ScriptableObject) only in Presentation & Infrastructure
	•	Events are defined as readonly struct → immutability guaranteed
	•	UI Naming Convention: ...View, ...Presenter, ...Binder

🛠️ Tech Stack
	•	Unity (2022+)
	•	C# (.NET Standard 2.1)
	•	ScriptableObjects for configuration
	•	Custom Event Bus for decoupled communication


🚀 Future Improvements
	•	✅ Reward inventory system
	•	✅ More roulette variations
	•	✅ Sound & particle effects integration
	•	✅ Save/Load system with persistence


## 🧑‍💻 Author

Developed by **Rojen Onat**  
📧 Contact: [LinkedIn](https://www.linkedin.com/in/rojenonat) 

