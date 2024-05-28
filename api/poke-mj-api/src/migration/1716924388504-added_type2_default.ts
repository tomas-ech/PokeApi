import { MigrationInterface, QueryRunner } from "typeorm";

export class AddedType2Default1716924388504 implements MigrationInterface {
    name = 'AddedType2Default1716924388504'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type1\` \`type1\` enum ('Ninguno', 'Hierba', 'Fuego') NOT NULL`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type2\` \`type2\` enum ('Ninguno', 'Hierba', 'Fuego') NOT NULL DEFAULT 'Ninguno'`);
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type2\` \`type2\` enum ('Hierba', 'Fuego') NOT NULL`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type1\` \`type1\` enum ('Hierba', 'Fuego') NOT NULL`);
    }

}
