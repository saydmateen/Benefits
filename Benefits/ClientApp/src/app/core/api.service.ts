import { HttpClient, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

export type HttpMethod = "GET" | "POST" | "PATCH" | "PUT" | "DELETE";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string
  ) {}

  public sendRequest<T>(
    path: string,
    method: HttpMethod,
    body?: any,
    params?: HttpParams
  ): Observable<T> {
    const fullUrl = this.getFullUrlPath(path);
    return this.http.request<T>(method, fullUrl, {
      body: body,
      params: params,
    });
  }

  public getFullUrlPath(path: string): string {
    return `${this.baseUrl}api/${path}`;
  }
}
