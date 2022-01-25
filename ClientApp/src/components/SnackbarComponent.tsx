import { Snackbar } from '@material-ui/core';
import React from 'react';
import { Alert } from '@mui/material';

export default function SnackbarComponent(props: any) {
  return (
    <Snackbar
      style={{ marginTop: '5em' }}
      open={props.open}
      onClose={props.handleClose}
      anchorOrigin={{ vertical: 'top', horizontal: 'center' }}
    >
      <Alert severity={props.severity}>{props.message}</Alert>
    </Snackbar>
  );
}
