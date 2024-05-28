import { Entity, PrimaryGeneratedColumn, Column, ManyToOne } from "typeorm"
import { Pokemon } from "./Pokemon"
import { User } from "./User"

@Entity()
export class UserCollection {

    @PrimaryGeneratedColumn()
    id: number

    @ManyToOne(() => User)
    user: User

    @ManyToOne(() => Pokemon)
    pokemon: Pokemon
}
