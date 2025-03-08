
import React, { useEffect, useState } from 'react';
import { CKEditor} from '@ckeditor/ckeditor5-react';
import * as  ClassicEditor from '@ckeditor/ckeditor5-build-classic';
export function CkEditor({value , onChange}) {
    const [isEditorReady, setIsEditorReady] = useState(false);

    useEffect(() => {
        setIsEditorReady(true);
    }, []);
    const editorValue = typeof value === 'string' ? value : JSON.stringify(value);
    return (
            <div className="relative overflow-hidden my-5 w-full rounded-xl border border-gray-300 bg-white text-left font-normal leading-5 text-gray-900">
                {isEditorReady && (
                    <CKEditor
                        editor={ ClassicEditor }
                        data={editorValue}
                        onReady={ editor => {
                            console.log( 'Editor is ready to use!', editor );
                        } }
                        onChange={(event , editor) =>{
                            const data = editor.getData();
                            onChange(data);
                            
                        }}
                    />
                )}
            </div>
    );
}