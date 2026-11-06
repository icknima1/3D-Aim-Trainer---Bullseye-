# 3D Aim Trainer

## Overview
The 3D Aim Trainer is a TypeScript-based application designed to help users improve their aiming skills in a 3D environment. The project includes various components, systems, and shaders to create an engaging training experience.

## Project Structure
```
3d-aim-trainer
├── public
│   └── index.html          # Main HTML entry point
├── src
│   ├── main.ts            # Main entry point for the TypeScript application
│   ├── app.ts             # Manages application state and scenes
│   ├── scenes
│   │   └── GameScene.ts   # Handles game logic and loop
│   ├── components
│   │   ├── Target.ts      # Represents target objects
│   │   └── HUD.ts         # Manages heads-up display
│   ├── systems
│   │   ├── InputSystem.ts  # Handles user input
│   │   ├── SpawnSystem.ts  # Manages target spawning
│   │   └── PhysicsSystem.ts # Handles physics calculations
│   ├── shaders
│   │   └── basic.glsl     # GLSL code for basic shaders
│   ├── utils
│   │   └── math.ts        # Utility functions for math operations
│   ├── types
│   │   └── index.ts       # TypeScript interfaces and types
│   └── styles
│       └── global.css     # Global styles for the application
├── tests
│   └── game.test.ts       # Unit tests for game logic and components
├── package.json            # npm configuration file
├── tsconfig.json           # TypeScript configuration file
├── vite.config.ts          # Vite configuration file
├── .eslintrc.json          # ESLint configuration file
├── .gitignore              # Git ignore file
└── README.md               # Project documentation
```

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   cd 3d-aim-trainer
   ```

2. Install dependencies:
   ```
   npm install
   ```

3. Run the application:
   ```
   npm run dev
   ```

4. Open your browser and navigate to `http://localhost:3000` to start training!

## Usage
- Use the mouse to aim at targets that spawn in the game scene.
- The HUD displays your score and timer, helping you track your performance.
- Adjust settings in the application as needed to customize your training experience.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any suggestions or improvements.

## License
This project is licensed under the MIT License. See the LICENSE file for details.