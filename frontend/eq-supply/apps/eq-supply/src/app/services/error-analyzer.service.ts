import { Injectable } from '@angular/core';

export interface IAppError {
  original?: any;
  message?: string;
  httpCode?: number;
  isHttpError?: boolean;
  isServerError?: boolean;
  isDOMException?: boolean;
  isNativeException?: boolean;
}

@Injectable()
export class ErrorAnalyzerService {
  constuctor() {}

  public get(ex: any, writeConsole: boolean = true): IAppError {
    const result: IAppError = {
      original: ex
    };
    if (!ex) {
      return null;
    }
    if (typeof ex === 'string') {
      result.message = ex;
    } else {
      if (ex instanceof DOMException) {
        result.isDOMException = true;
        result.message = 'Произошла ошибка при создании разметки на странице';
      } else if (ex.status >= 500) {
        result.isServerError = true;
        result.message = this.getStackedMessageFromServerError(ex);
      } else if (ex.status >= 400 && ex.status < 500) {
        result.httpCode = ex.status;
        result.isHttpError = true;
        if (ex.status > 401 || ex.status === 400) {
          result.isServerError = true;
          result.message = this.getStackedMessageFromServerError(ex.error);
        } else if (ex.status === 401) {
          result.message = ex.message;
        }
      } else {
        result.isNativeException = true;
        result.message = ex.message;
      }
    }
    if (writeConsole) {
      console.error(result);
    }
    if (!result.message) {
      result.message = 'Произошла ошибка';
    }
    return result;
  }

  private getStackedMessageFromServerError(ex: any): string {
    if (ex.modelState) {
      return this.getModelStateErrors(ex.modelState);
    } else if (ex.error) {
      return this.getStackedMessageFromServerError(ex.error);
    }else if(ex.message){
      return ex.message;
    }else{
      return this.getModelStateErrors(ex)
    }

    let result = '';
    if (ex.exceptionMessage) {
      try {
        const s: any = JSON.parse(ex.exceptionMessage);
        result += ' ' + this.getStackedMessageFromServerError(s);
      } catch (nex) {
        result = ex.exceptionMessage;
      }
    }
    if (ex.innerException) {
      result += ' ' + this.getStackedMessageFromServerError(ex.innerException);
    }
    if (result.length === 0) {
      result = ex.message || ex;
    }
    return result;
  }

  private getModelStateErrors(modelState: any): string {
    let result: string = '';
    if (modelState != null) {
      for (var propertyName in modelState) {
        const propertyErrors: Array<string> = modelState[propertyName];
        if (propertyErrors && propertyErrors.length > 0) {
          propertyErrors.forEach(error => {
            result += error;
          });
          result + '\r\n';
        }
      }
      if (result.length > 0) {
        result = 'Ваш запрос содержит следующие ошибки:\r\n' + result;
      }
    }
    return result.length > 0 ? result : null;
  }
}
