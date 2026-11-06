class GameScene {
    private targets: Target[];
    private hud: HUD;
    private inputSystem: InputSystem;
    private spawnSystem: SpawnSystem;
    private physicsSystem: PhysicsSystem;
    private score: number;
    private timer: number;

    constructor() {
        this.targets = [];
        this.hud = new HUD();
        this.inputSystem = new InputSystem();
        this.spawnSystem = new SpawnSystem();
        this.physicsSystem = new PhysicsSystem();
        this.score = 0;
        this.timer = 0;
    }

    public init(): void {
        this.spawnSystem.init();
        this.hud.init();
        this.startGameLoop();
    }

    private startGameLoop(): void {
        const loop = () => {
            this.update();
            this.render();
            requestAnimationFrame(loop);
        };
        loop();
    }

    private update(): void {
        this.physicsSystem.update(this.targets);
        this.hud.update(this.score, this.timer);
        this.timer += 1 / 60; // Assuming 60 FPS
    }

    private render(): void {
        // Render logic for the game scene
    }

    public onTargetHit(target: Target): void {
        this.score += 1;
        this.targets = this.targets.filter(t => t !== target);
    }
}

export default GameScene;