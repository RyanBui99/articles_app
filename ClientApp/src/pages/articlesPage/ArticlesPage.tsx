import React from 'react';
import Articles from '../../components/Articles';
import Header from '../../components/Header';
import Grid from '@mui/material/Grid';
import { makeStyles } from '@mui/styles';

// const useStyles = makeStyles({
//   root: {
//     display: 'flex',
//     flexDirection: 'column',
//     justifyContent: 'center',
//   },
// });

export default function ArticlesPage() {
//   const classes = useStyles();
  return (
    <>
      <Header />
      <Grid justifyContent='center' sx={{ flexGrow: 1 }} container spacing={4} marginTop='2em'>
        {[0, 1, 2, 3].map((value: number) => (
          <Grid key={value} item>
            <Articles />
          </Grid>
        ))}
      </Grid>
    </>
  );
}
