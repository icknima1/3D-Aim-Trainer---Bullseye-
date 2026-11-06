import { GameScene } from './scenes/GameScene';
import { InputSystem } from './systems/InputSystem';
import { SpawnSystem } from './systems/SpawnSystem';
import { PhysicsSystem } from './systems/PhysicsSystem';

class App {
    private gameScene: GameScene;
    private inputSystem: InputSystem;
    private spawnSystem: SpawnSystem;
    private physicsSystem: PhysicsSystem;

    constructor() {
        this.gameScene = new GameScene();
        this.inputSystem = new InputSystem();
        this.spawnSystem = new SpawnSystem();
        this.physicsSystem = new PhysicsSystem();
    }

    public start() {
        this.gameScene.initialize();
        this.inputSystem.initialize();
        this.spawnSystem.initialize();
        this.physicsSystem.initialize();
        this.gameLoop();
    }

    private gameLoop() {
        requestAnimationFrame(() => this.gameLoop());
        this.physicsSystem.update();
        this.gameScene.update();
        this.spawnSystem.update();
        this.inputSystem.update();
    }
}

const app = new App();
app.start();