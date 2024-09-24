import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from '../models/Categoria';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json' 
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  //As duas formas abaixo estão corretas
  //url:string = 'api/Categorias';
  url = 'api/Categorias';

  constructor(private http: HttpClient) { }

  PegarTodos(): Observable<Categoria[]>{
    return this.http.get<Categoria[]>(this.url);
  }

  /* Usar aspa invertida 
  No caso abaixo vai ficar api/Categoria/Id
  Exemplo: api/Categoria/4  */
  PegarCategoriaPeloId(categoriaId: number) : Observable<Categoria>{
    const apiUrl = `${this.url}/${categoriaId}`;
    return this.http.get<Categoria>(apiUrl);
  }

  /* Inserir uma nova categoria no banco de dados 
  Vamos retornar um tipo de dado que não vai ser definido aqui, ou seja,
  Observable<any> vai ser definido em tempo de execução. */
  NovaCategoria(categoria: Categoria) : Observable<any>{
    return this.http.post<Categoria>(this.url, categoria, httpOptions);
  }

  /* Recebe o Id da categoria e a categoria que deve ser atualizada
  Vamos retornar um tipo de dados desconhecido  Observable<any> */
  AtualizarCategoria(categoriaId: number, categoria: Categoria) : Observable<any>{
    const apiUrl = `${this.url}/${categoriaId}`;
    return this.http.put<Categoria>(apiUrl, categoria, httpOptions);
  }

  /* Para excluir uma Categoria precisamos do Id 
  Será retornado algo que desconhecemos Observable<any> */
  ExcluirCategoria(categoriaId: number) : Observable<any>{
    const apiUrl = `${this.url}/${categoriaId}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}   
  