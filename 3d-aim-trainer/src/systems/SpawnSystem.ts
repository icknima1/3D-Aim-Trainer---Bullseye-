export class SpawnSystem {
    private spawnInterval: number;
    private lastSpawnTime: number;

    constructor(spawnInterval: number) {
        this.spawnInterval = spawnInterval;
        this.lastSpawnTime = 0;
    }

    public update(currentTime: number): void {
        if (currentTime - this.lastSpawnTime >= this.spawnInterval) {
            this.spawnTarget();
            this.lastSpawnTime = currentTime;
        }
    }

    private spawnTarget(): void {
        // Logic to spawn a new target
        console.log("Target spawned!");
    }
}