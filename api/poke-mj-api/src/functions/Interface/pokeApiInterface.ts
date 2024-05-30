export interface ListPokemon {
    count: number,
    results: {
        name: string,
        url: string,
    }[]
}